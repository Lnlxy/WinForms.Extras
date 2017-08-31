using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 命令管理器。
    /// </summary>
    public static class CommandManager
    {
        private static readonly List<CommandBinding> commandBindings = new List<CommandBinding>();

        /// <summary>
        /// 获取所有绑定信息。
        /// </summary>
        public static IEnumerable<CommandBinding> CommandBindings { get => commandBindings; }

        /// <summary> 
        /// 添加绑定信息到指定的组件。
        /// </summary>
        /// <remarks>
        /// 绑定要求：需指定组件的默认事件和 Enabled 属性。
        /// 默认事件：<see cref="DefaultEventAttribute"/> 标记。
        /// 默认属性：Enabled 显示实现。
        /// </remarks>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TParameter">参数类型。</typeparam>
        /// <param name="component">组件。</param>
        /// <param name="command">命令。</param>
        /// <param name="source">数据源。</param>
        /// <param name="parameterExpression">参数表达式。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 实例。</returns>
        public static CommandBinding Add<TSource, TParameter>(Component component, ICommand command, TSource source, Expression<Func<TSource, TParameter>> parameterExpression)
        {
            var member = parameterExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return Add(component, command, source, member.Member.Name);
        }

        /// <summary>
        /// 添加绑定信息到指定的组件。
        /// </summary>
        /// <remarks>
        /// 绑定要求：需指定组件的默认事件和 Enabled 属性。
        /// 默认事件：<see cref="DefaultEventAttribute"/> 标记。
        /// 默认属性：Enabled 显示实现。
        /// </remarks>
        /// <param name="component">组件。</param>
        /// <param name="command">命令。</param>
        /// <param name="staticSourceType">静态数据源类型。</param>
        /// <param name="parameter">参数。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 实例。</returns>
        public static CommandBinding Add(Component component, ICommand command, Type staticSourceType, string parameter)
        {
            return Add(component, command, new CommandParameter(staticSourceType, parameter));
        }

        /// <summary>
        /// 添加绑定信息到指定的组件。
        /// </summary>
        /// <remarks>
        /// 绑定要求：需指定组件的默认事件和 Enabled 属性。
        /// 默认事件：<see cref="DefaultEventAttribute"/> 标记。
        /// 默认属性：Enabled 显示实现。
        /// </remarks>
        /// <param name="component">组件。</param>
        /// <param name="command">命令。</param>
        /// <param name="source">数据源。</param>
        /// <param name="parameter">参数。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 实例。</returns>
        public static CommandBinding Add(Component component, ICommand command, Object source, string parameter)
        {
            return Add(component, command, new CommandParameter(source, parameter));
        }

        /// <summary>
        /// 添加绑定信息到指定的组件。
        /// </summary>
        /// <remarks>
        /// 绑定要求：需指定组件的默认事件和 Enabled 属性。
        /// 默认事件：<see cref="DefaultEventAttribute"/> 标记。
        /// 默认属性：Enabled 显示实现。
        /// </remarks>
        /// <param name="component">组件。</param>
        /// <param name="command">命令。</param>
        /// <param name="commandParameter">命令参数。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 实例。</returns>
        public static CommandBinding Add(Component component, ICommand command, CommandParameter commandParameter)
        {
            return Add(component, new CommandSource(command, commandParameter));
        }

        /// <summary>
        /// 添加绑定信息到指定的组件。
        /// </summary>
        /// <remarks>
        /// 绑定要求：需指定组件的默认事件和 Enabled 属性。
        /// 默认事件：<see cref="DefaultEventAttribute"/> 标记。
        /// 默认属性：Enabled 显示实现。
        /// </remarks>
        /// <param name="component">组件。</param>
        /// <param name="commandSource">命令源。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 实例。</returns>
        public static CommandBinding Add(Component component, CommandSource commandSource)
        {
            var @event = TypeDescriptor.GetDefaultEvent(component);
            var binding = new CommandBinding(commandSource, new ComponentTarget(component, @event));
            commandBindings.Add(binding);
            return binding;
        } 
    }
}
