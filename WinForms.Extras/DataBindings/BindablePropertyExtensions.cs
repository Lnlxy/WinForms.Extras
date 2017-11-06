using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    public static class BindablePropertyExtensions
    {
        /// <summary>
        /// 创建默认绑定属性。
        /// </summary>
        /// <param name="component">此组件实例。</param>
        /// <returns>返回 <see cref="IBindableProperty"/> 新实例。</returns>
        public static IBindableProperty Property(this Component component)
        {
            var componentType = component.GetType();
            if (component is IBindableComponent)
            {
                var attributeType = typeof(DefaultBindingPropertyAttribute);
                if (!componentType.IsDefined(attributeType, true))
                {
                    throw new ArgumentException();
                }
                var attribute = componentType.GetCustomAttributes(attributeType, true)
                    .OfType<DefaultBindingPropertyAttribute>()
                    .First();
                return new BindableComponentProperty((IBindableComponent)component, attribute.Name);
            }
            else
            {
                var attributeType = typeof(DefaultPropertyAttribute);
                if (!componentType.IsDefined(attributeType, true))
                {
                    throw new ArgumentException();
                }
                var attribute = componentType.GetCustomAttributes(attributeType, true)
                    .OfType<DefaultPropertyAttribute>()
                    .First();
                return new ComponentProperty(component, attribute.Name);
            }
        }

        /// <summary>
        /// 创建绑定属性。
        /// </summary>
        /// <param name="component">此组件实例。</param>
        /// <param name="propertyName">属性名称。</param>
        /// <returns>返回 <see cref="IBindableProperty"/> 新实例。</returns>
        public static IBindableProperty Property(this Component component, string propertyName)
        {
            if (component is IBindableComponent)
            {
                return new BindableComponentProperty((IBindableComponent)component, propertyName);
            }
            else
            {
                return new ComponentProperty(component, propertyName);
            }
        }

        /// <summary>
        /// 创建绑定属性。
        /// </summary>
        /// <typeparam name="TComponent">此组件类型。</typeparam>
        /// <typeparam name="TProperty">绑定属性类型。</typeparam>
        /// <param name="component">此组件实例。</param>
        /// <param name="expression">属性名称表达式。</param>
        /// <returns>返回 <see cref="IBindableProperty"/> 新实例。</returns>
        public static IBindableProperty Property<TComponent, TProperty>(this TComponent component, Expression<Func<TComponent, TProperty>> expression) where TComponent : Component
        {
            var property = (expression.Body as MemberExpression).Member.Name;
            return Property(component, property);
        }

        ///<summary>
        /// 设置控件更新方式。
        /// </summary>
        /// <typeparam name="Binding">绑定类型。</typeparam>
        /// <param name="property">源。</param>
        /// <param name="mode">模式。</param>
        /// <returns>返回设置完成后的 <typeparamref name="IBindableProperty"/>。</returns>
        public static IBindableProperty SetControlUpdateMode(this IBindableProperty property, ControlUpdateMode mode)
        {
            property.ControlUpdateMode = mode;
            return property;
        }

        /// <summary>
        /// 设置数据源更新方式。
        /// </summary>
        /// <typeparam name="Binding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="mode">模式。</param>
        /// <returns>返回设置完成后的 <typeparamref name="IBindableProperty"/>。</returns>
        public static IBindableProperty SetDataSourceUpdateMode(this IBindableProperty property, DataSourceUpdateMode mode)
        {
            property.DataSourceUpdateMode = mode;
            return property;
        }
    }
}
