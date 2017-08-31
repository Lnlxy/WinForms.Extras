using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Windows.Froms.Commands
{
    public class CommandParameter
    {
        private readonly PropertyInfo _property;
        public Object Source { get; private set; }

        public Type StaticSourceType { get; private set; }

        public string ParameterName { get; private set; }

        public object ParameterValue => GetParameterValue();

        public event EventHandler ParameterValueChanged;

        public CommandParameter(Object source, string parameterName)
        {
            _property = source.GetType().GetProperty(parameterName);
            if (_property == null)
            {
                throw new MemberAccessException($"Type:{source.GetType().FullName}, Property:{parameterName}");
            }
            if (source is INotifyPropertyChanged)
            {
                ((INotifyPropertyChanged)Source).PropertyChanged += OnPropertyChanged;
            }
            Source = source;
            ParameterName = parameterName;
        }

        public CommandParameter(Type staticSourceType, string parameterName)
        {
            _property = staticSourceType.GetProperty(parameterName, BindingFlags.Static);
            if (_property == null)
            {
                throw new MemberAccessException($"Type:{staticSourceType.FullName}, Property:{parameterName}");
            }
            if (staticSourceType.IsAssignableFrom(typeof(INotifyPropertyChanged)))
            {
                staticSourceType.GetEvent("PropertyChanged").AddEventHandler(null, (PropertyChangedEventHandler)OnPropertyChanged);
            }
            StaticSourceType = staticSourceType;
            ParameterName = parameterName;
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(ParameterName))
            {
                ParameterValueChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private object GetParameterValue()
        {
            return Source == null ? _property.GetValue(null, null) : _property.GetValue(Source, null);
        }

        public static CommandParameter Create<TSource, TParameter>(TSource source, Expression<Func<TSource, TParameter>> parameterNameExpress)
        {
            var member = parameterNameExpress.Body as MemberExpression;
            var parameter = member.Member.Name;
            return new CommandParameter(source, parameter);
        }
    }
}
