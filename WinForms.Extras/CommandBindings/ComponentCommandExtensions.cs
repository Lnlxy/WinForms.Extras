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
        public static void Command(this Component component, ICommand command, IValueObject commandParameter)
        {
            component.Event().Command(command, commandParameter);
        }
        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="component">目标组件</param>
        /// <param name="command">命令。</param>
        /// <param name="commandParameter">命令执行参数。</param> 
        public static void Command(this Component component, ICommand command, ValueObject commandParameter)
        {
            component.Event().Command(command, commandParameter);
        }

        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TParameter">数据源成员。</typeparam>
        /// <param name="component">目标组件</param>
        /// <param name="command">命令。</param>
        /// <param name="source">数据源。</param>
        /// <param name="expression">参数表达式。</param> 
        public static void Command<TSource, TParameter>(this Component component, ICommand command, TSource source, Expression<Func<TSource, TParameter>> expression)
        {
            component.Event().Command(command, source, expression);
        }
    }
}
