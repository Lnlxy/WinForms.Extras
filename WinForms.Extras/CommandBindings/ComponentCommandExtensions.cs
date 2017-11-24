using System.ComponentModel;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 提供对组件或控件的命令注册。
    /// </summary>
    public static class ComponentCommandExtensions
    {
        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="component">目标组件</param>
        /// <param name="command">命令。</param> 
        public static void Command(this Component component, ICommand command)
        {
            component.Event().Command(command);
        }
        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="component">目标组件</param>
        /// <param name="command">命令。</param>
        /// <param name="commandParameter">命令执行参数。</param> 
        public static void Command(this Component component, ICommand command, object commandParameter)
        {
            component.Event().Command(command, commandParameter);
        }
    }
}
