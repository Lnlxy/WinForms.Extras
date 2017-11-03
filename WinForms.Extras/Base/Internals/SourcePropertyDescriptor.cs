using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace System.Windows.Forms.Internals
{
    internal class SourcePropertyDescriptor : SourceMemberDescriptor
    {
        private readonly PropertyInfo _property;

        private readonly Dictionary<object, EventHandler> events = new Dictionary<object, EventHandler>();

        private readonly object syncObj = new object();

        public SourcePropertyDescriptor(PropertyInfo propertyInfo) : base(propertyInfo.Name)
        {
            _property = propertyInfo;
        }

        public bool IsReadOnly { get => !_property.CanWrite; }

        public Type PropertyType { get => _property.PropertyType; }

        public Type ReflectedType { get => _property.ReflectedType; }

        public void AddValueChanged(object source, EventHandler eventHandler)
        {
            if (source is Component)
            {
                var eventName = $"{_property.Name}Changed";
                var evnt = _property.ReflectedType.GetEvent(eventName);
                if (evnt?.GetType().IsAssignableFrom(eventHandler.GetType()) ?? false)
                {
                    evnt.AddEventHandler(source, eventHandler);
                }
            }
            if (source is INotifyPropertyChanged)
            {
                source.GetType().GetEvent(nameof(INotifyPropertyChanged.PropertyChanged)).AddEventHandler(source, (PropertyChangedEventHandler)OnPropertyChanged);
                lock (syncObj)
                {
                    if (!events.ContainsKey(source))
                    {
                        events.Add(source, (EventHandler)Delegate.Combine(eventHandler));
                    }
                    else
                    {
                        events[source] += eventHandler;
                    }
                }
            }
        }

        public object GetValue(object source)
        {
            return _property.GetValue(source, null);
        }

        public void RemoveValueChanged(object source, EventHandler eventHandler)
        {
            if (typeof(Component).IsAssignableFrom(_property.ReflectedType))
            {
                var eventName = $"{_property.Name}Changed";
                var evnt = _property.ReflectedType.GetEvent(eventName);
                if (evnt?.GetType().IsAssignableFrom(eventHandler.GetType()) ?? false)
                {
                    evnt.RemoveEventHandler(source, eventHandler);
                }
            }
            if (typeof(INotifyPropertyChanged).IsAssignableFrom(_property.ReflectedType))
            {
                _property.ReflectedType.GetEvent(nameof(INotifyPropertyChanged.PropertyChanged)).RemoveEventHandler(source, (PropertyChangedEventHandler)OnPropertyChanged);
                lock (syncObj)
                {
                    if (events.ContainsKey(source))
                    {
                        events[source] -= eventHandler;
                    }
                }
            }
        }

        public void SetValue(object source, object value)
        {
            if (_property.CanWrite)
            {
                _property.SetValue(source, value, null);
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(_property.Name))
            {
                events[sender]?.Invoke(sender, e);
            }
        }
    }
}
