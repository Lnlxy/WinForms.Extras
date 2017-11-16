using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 对组件的拓展。
    /// </summary>
    public static class ComponentEventExtensions
    {
        /// <summary>
        /// 创建组件的默认事件信息。
        /// </summary>
        /// <param name="component">组件。</param>
        /// <returns></returns>
        public static ComponentEvent Event(this Component component)
        {
            var attribute = component.GetType().GetCustomAttributes(typeof(DefaultEventAttribute), true).FirstOrDefault() as DefaultEventAttribute;
            return Event(component, attribute.Name);
        }

        /// <summary>
        /// 创建组件指定名称的事件信息。
        /// </summary>
        /// <param name="component">组件。</param>
        /// <param name="eventName">事件名称。</param>
        /// <returns></returns>
        public static ComponentEvent Event(this Component component, string eventName)
        {
            return new ComponentEvent(component, eventName);
        }
    }
}
