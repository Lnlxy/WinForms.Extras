using System.ComponentModel;

namespace System.Windows.Forms
{
    /// <summary>
    /// 命令目标组件。
    /// </summary>
    public sealed class ComponentTarget
    {
        private readonly Component _component;
        private readonly PropertyDescriptor _enabledProperty;
        private readonly EventDescriptor _event;

        /// <summary>
        /// 设置一个值，该值表示是否启用组件。
        /// </summary>
        /// <remarks>需组件默认实现 Enabled 属性。</remarks>
        public bool Enabled
        {
            get
            {
                return (bool)_enabledProperty.GetValue(_component);
            }
            internal set
            {
                _enabledProperty.SetValue(_component, value);
            }
        }

        /// <summary>
        /// 当组件默认事件触发时，发生。
        /// </summary>
        public event EventHandler DefaultEventHandled
        {
            add { _event.AddEventHandler(_component, value); }
            remove { _event.RemoveEventHandler(_component, value); }
        }
        internal ComponentTarget(Component component, EventDescriptor defaultEvent)
        {
            _component = component;
            _event = defaultEvent;
            _enabledProperty = TypeDescriptor.GetProperties(component).Find("Enabled", false);

        }
    }
}
