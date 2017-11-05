using System.Linq.Expressions;
using System.ComponentModel;
using System.Linq;
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
        /// 创建由 <see cref="DefaultBindingPropertyAttribute"/>标记绑定的默认属性。
        /// </summary>
        /// <param name="component">此组件实例。</param>
        /// <returns>返回 <see cref="BindableComponentProperty"/> 新实例。</returns>
        public static BindableComponentProperty Property(this IBindableComponent component)
        {
            var componentType = component.GetType();
            var attributeType = typeof(DefaultBindingPropertyAttribute);
            if (!componentType.IsDefined(attributeType, true))
            {
                throw new ArgumentException();
            }
            var attribute = componentType.GetCustomAttributes(attributeType, true)
                .OfType<DefaultBindingPropertyAttribute>()
                .First();
            return new BindableComponentProperty(component, attribute.Name);
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
