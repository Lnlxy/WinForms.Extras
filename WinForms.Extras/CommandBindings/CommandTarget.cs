using System.ComponentModel;
using System.Linq;

namespace System.Windows.Forms
{

    /// <summary>
    /// 命令目标组件。
    /// </summary>
    sealed class CommandTarget
    {
        private readonly Internals.SourcePropertyDescriptor _enabledProperty;
        private readonly Internals.SourceEventDescriptor _defaultEvent;
        public Component Component { get; private set; }

        public void UpdateState(bool state)
        {
            _enabledProperty.SetValue(Component, state);
        }
        public void DoEvent(EventHandler eventHandler)
        {
            _defaultEvent.AddEventHandler(Component, eventHandler);
        }
        internal CommandTarget(Component component)
        {
            Component = component;
            var eventName = GetDefaultEventName(component.GetType());
            _defaultEvent = Internals.SourceTypeDescriptor.GetEvent(component, eventName);
            _enabledProperty = Internals.SourceTypeDescriptor.GetProperty(component, "Enabled");
        }

        private static string GetDefaultEventName(Type type)
        {
            var attribute = type.GetCustomAttributes(typeof(DefaultEventAttribute), true).FirstOrDefault() as DefaultEventAttribute;
            return attribute?.Name ?? string.Empty;
        }
    }
}
