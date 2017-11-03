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
        /// <param name="commandSource">命令源。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public static CommandBinding Command(this Component component, CommandSource commandSource)
        {
            return CommandManager.Add(component, commandSource);
        }

        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="component">目标组件</param>
        /// <param name="command">命令。</param>
        /// <param name="commandParameter">命令执行参数。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public static CommandBinding Command(this Component component, ICommand command, CommandParameter commandParameter)
        {
            return Command(component, new CommandSource(command, commandParameter));
        }

        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="component">目标组件</param>
        /// <param name="command">命令。</param>
        /// <param name="source">数据源。</param>
        /// <param name="parameter">参数。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public static CommandBinding Command(this Component component, ICommand command, Object source, string parameter)
        {
            return Command(component, command, new CommandParameter(source, parameter));
        }

        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TParameter">数据源成员。</typeparam>
        /// <param name="component">目标组件</param>
        /// <param name="command">命令。</param>
        /// <param name="source">数据源。</param>
        /// <param name="parameterExpression">参数表达式。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public static CommandBinding Command<TSource, TParameter>(this Component component, ICommand command, TSource source, Expression<Func<TSource, TParameter>> parameterExpression)
        {
            var member = parameterExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return Command(component, command, source, member.Member.Name);
        }

        public static void Command<TSource, TParameter>(this Component component, TSource source, Expression<Func<TSource, TParameter>> parameterExpression, Action<TParameter> execute, Func<TParameter, bool> canexecute)
        {
            Command(component, new RelayCommand<TParameter>(execute, canexecute), source, parameterExpression);
        }
    }
}
