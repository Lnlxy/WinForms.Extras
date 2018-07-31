// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="BindablePropertyExtensions.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 拓展方法。
    /// </summary>
    public static class BindablePropertyExtensions
    {
        #region Methods

        /// <summary>
        /// 创建由组件指定的默认属性的绑定属性。
        /// </summary>
        /// <remarks>
        /// 若组件继承<see cref="IBindableComponent"/> 则获取由 <see cref="DefaultBindingPropertyAttribute"/> 标记的值为默认属性。
        /// 否则则获取由 <see cref="DefaultPropertyAttribute"/> 标记的值为默认属性。
        /// 若一个组件未指定以上两个标记时，则抛出异常。
        /// </remarks>
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
        /// <param name="property">源。</param>
        /// <param name="mode">模式。</param>
        /// <returns></returns>
        public static IBindableProperty SetControlUpdateMode(this IBindableProperty property, ControlUpdateMode mode)
        {
            property.ControlUpdateMode = mode;
            return property;
        }

        /// <summary>
        /// 设置数据源更新方式。
        /// </summary>
        /// <param name="property">属性。</param>
        /// <param name="mode">模式。</param>
        public static IBindableProperty SetDataSourceUpdateMode(this IBindableProperty property, DataSourceUpdateMode mode)
        {
            property.DataSourceUpdateMode = mode;
            return property;
        }

        #endregion
    }
}
