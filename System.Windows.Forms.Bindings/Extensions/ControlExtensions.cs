using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 提创建命令绑定的方法。
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// 返回控件指定属性的绑定构建器。
        /// </summary>
        /// <param name="control">控件。</param>
        /// <param name="propertyName">属性名称。</param>
        /// <returns>返回 <see cref="DataBindingBuilder"/> 实例。</returns>
        public static DataBindingBuilder CreateDataBindingBuilder(this Control control, string propertyName)
        {
            return new DataBindingBuilder(control, propertyName);
        }

        /// <summary>
        /// 返回控件指定属性的绑定构建器。
        /// </summary>
        /// <typeparam name="TControl">控件类型。</typeparam>
        /// <typeparam name="TProperty">控件属性</typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyNameExpression">属性表达式。</param>
        /// <returns>返回 <see cref="DataBindingBuilder"/> 实例。</returns>
        public static DataBindingBuilder CreateDataBindingBuilder<TControl, TProperty>(this TControl control, Expression<Func<TControl, TProperty>> propertyNameExpression) where TControl : Control
        {
            var member = propertyNameExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return CreateDataBindingBuilder(control, member.Member.Name);
        }   /// <summary>
            /// 返回控件指定属性的绑定构建器。
            /// </summary>
            /// <param name="control">控件。</param>
            /// <param name="propertyName">属性名称。</param>
            /// <returns>返回 <see cref="DataBindingBuilder"/> 实例。</returns>
        public static MultiDataBindingBuilder CreateMultiDataBindingBuilder(this Control control, string propertyName)
        {
            return new MultiDataBindingBuilder(control, propertyName);
        }

        /// <summary>
        /// 返回控件指定属性的绑定构建器。
        /// </summary>
        /// <typeparam name="TControl">控件类型。</typeparam>
        /// <typeparam name="TProperty">控件属性</typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyNameExpression">属性表达式。</param>
        /// <returns>返回 <see cref="DataBindingBuilder"/> 实例。</returns>
        public static MultiDataBindingBuilder CreateMultiDataBindingBuilder<TControl, TProperty>(this TControl control, Expression<Func<TControl, TProperty>> propertyNameExpression) where TControl : Control
        {
            var member = propertyNameExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return CreateMultiDataBindingBuilder(control, member.Member.Name);
        }
    }
}
