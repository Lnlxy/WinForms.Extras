using System.Linq.Expressions;

namespace System.Windows.Forms
{
    public static class BindableComponetExtensions
    {
        /// <summary>
        /// 创建绑定属性。
        /// </summary>
        /// <param name="component">此组件实例。</param>
        /// <param name="propertyName">属性名称。</param>
        /// <returns>返回 <see cref="BindableComponentProperty"/> 新实例。</returns>
        public static BindableComponentProperty Property(this IBindableComponent component, string propertyName)
        {
            return new BindableComponentProperty(component, propertyName);
        }

        /// <summary>
        /// 创建绑定属性。
        /// </summary>
        /// <typeparam name="TComponent">此组件类型。</typeparam>
        /// <typeparam name="TProperty">绑定属性类型。</typeparam>
        /// <param name="component">此组件实例。</param>
        /// <param name="expression">属性名称表达式。</param>
        /// <returns>返回 <see cref="BindableComponentProperty"/> 新实例。</returns>
        public static BindableComponentProperty Property<TComponent, TProperty>(this TComponent component, Expression<Func<TComponent, TProperty>> expression) where TComponent : IBindableComponent
        {
            var property = (expression.Body as MemberExpression).Member.Name;
            return new BindableComponentProperty(component, property);
        }
    }
}
