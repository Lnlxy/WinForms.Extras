﻿using System.Globalization;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 提创建命令绑定的方法。
    /// </summary>
    public static class ControlBindingExtensions
    {
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <param name="component">组件。</param>
        /// <param name="propertyName">绑定的属性。</param> 
        /// <param name="multiDataBoundItem">绑定的数据成员。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding(this IBindableComponent component, string propertyName, MultiBindableValue multiDataBoundItem, IMultiValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            var binding = new MultiDataBinding(propertyName, multiDataBoundItem, converter, convertParameter, culture);
            component.DataBindings.Add(binding);
            return binding;
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <param name="component">组件。</param>
        /// <param name="propertyName">绑定的属性。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dateMember">绑定的数据成员。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding(this IBindableComponent component, string propertyName, object dataSource, string dataMember, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            var binding = new DataBinding(propertyName, dataSource, dataMember, converter, convertParameter, culture);
            component.DataBindings.Add(binding);
            return binding;
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <param name="component">组件。</param>
        /// <param name="propertyName">绑定的属性。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dateMember">绑定的数据成员。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding(this IBindableComponent component, string propertyName, object dataSource, string dateMember)
        {
            return component.DataBindings.Add(propertyName, dataSource, dateMember);
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMember">数据成员类型。</typeparam>
        /// <param name="component">组件。</param>
        /// <param name="propertyName">绑定的属性。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMemberExpression">数据成员表达式。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TSource, TMember>(this IBindableComponent component, string propertyName, TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression)
        {
            var member = dataMemberExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return Binding(component, propertyName, dataSource, member.Member.Name);
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TMember"></typeparam>
        /// <param name="component">组件。</param>
        /// <param name="propertyName">绑定的属性。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dataMemberExpression">数据成员表达式。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TSource, TMember>(this IBindableComponent component, string propertyName, TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            var member = (dataMemberExpression.Body as MemberExpression).Member.Name;
            return Binding(component, propertyName, dataSource, member, converter, convertParameter, culture);
        }

        public static Binding Binding(this IBindableComponent component, string propertyName, Type dataSourceType, string dateMember)
        {
            var dataSource = new BindableValue(dataSourceType, dateMember);
            return component.DataBindings.Add(propertyName, dataSource, "Value");
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TComponent">组件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <param name="component">组件。</param>
        /// <param name="propertyExpression">绑定的成员表达式。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dateMember">绑定的数据成员。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TComponent, TProperty>(this TComponent component, Expression<Func<TComponent, TProperty>> propertyExpression, object dataSource, string dataMember) where TComponent : IBindableComponent
        {
            var property = propertyExpression.Body as MemberExpression;
            if (property.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{property.Member.Name} is not a property.");
            }
            return Binding(component, property.Member.Name, dataSource, dataMember);
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TComponent">组件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMember">数据成员类型。</typeparam>
        /// <param name="component">组件。</param>
        /// <param name="propertyExpression">绑定的成员表达式。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMemberExpression">数据成员表达式。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TComponent, TProperty, TSource, TMember>(this TComponent component, Expression<Func<TComponent, TProperty>> propertyExpression, TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression) where TComponent : IBindableComponent
        {
            var property = propertyExpression.Body as MemberExpression;
            if (property.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{property.Member.Name} is not a property.");
            }
            var member = dataMemberExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return Binding(component, property.Member.Name, dataSource, member.Member.Name);
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TComponent">组件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMember">数据成员类型。</typeparam>
        /// <param name="component">组件。</param>
        /// <param name="propertyExpression">绑定的成员表达式。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMemberExpression">数据成员表达式。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TComponent, TProperty, TSource, TMember>(this TComponent component, Expression<Func<TComponent, TProperty>> propertyExpression, TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression, IValueConverter converter, object convertParameter = null, CultureInfo culture = null) where TComponent : IBindableComponent
        {
            var property = (propertyExpression.Body as MemberExpression).Member.Name;
            var member = (dataMemberExpression.Body as MemberExpression).Member.Name;
            return Binding(component, property, dataSource, member, converter, convertParameter, culture);
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TComponent">组件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <param name="component">组件。</param>
        /// <param name="propertyExpression">绑定的成员表达式。</param>
        /// <param name="dataSourceType">静态类类型。。</param>
        /// <param name="dataMember">绑定的数据成员。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TComponent, TProperty>(this TComponent component, Expression<Func<TComponent, TProperty>> propertyExpression, Type dataSourceType, string dataMember) where TComponent : IBindableComponent
        {
            var property = propertyExpression.Body as MemberExpression;
            if (property.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{property.Member.Name} is not a property.");
            }
            return Binding(component, property.Member.Name, dataSourceType, dataMember);
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TComponent">组件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <param name="component">组件。</param>
        /// <param name="propertyNameExpression">绑定的成员表达式。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dateMember">绑定的数据成员。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TComponent, TProperty>(this TComponent component, Expression<Func<TComponent, TProperty>> propertyNameExpression, object dataSource, string dataMember, IValueConverter converter, object convertParameter = null, CultureInfo culture = null) where TComponent : IBindableComponent
        {
            var property = (propertyNameExpression.Body as MemberExpression).Member.Name;
            return Binding(component, property, dataSource, dataMember, converter, convertParameter, culture);
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TComponent">组件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <param name="component">组件。</param>
        /// <param name="properyExpression">绑定的成员表达式。</param>
        /// <param name="multiDataBoundItem">绑定的数据成员。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TComponent, TProperty>(this TComponent component, Expression<Func<TComponent, TProperty>> properyExpression, MultiBindableValue multiDataBoundItem, IMultiValueConverter converter, object convertParameter = null, CultureInfo culture = null) where TComponent : IBindableComponent
        {
            var property = properyExpression.Body as MemberExpression;
            if (property.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{property.Member.Name} is not a property.");
            }
            return Binding(component, property.Member.Name, multiDataBoundItem, converter, convertParameter, culture);
        }
    }
}