// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 10-20-2017
//
// ***********************************************************************
// <copyright file="controlextensions.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2017 (c) Park Plus Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 提创建命令绑定的方法。
    /// </summary>
    public static class ControlExtensions
    {
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <param name="control">控件。</param>
        /// <param name="propertyName">绑定的属性。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dateMember">绑定的数据成员。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding(this Control control, string propertyName, object dataSource, string dateMember)
        {
            return control.DataBindings.Add(propertyName, dataSource, dateMember);
        }

        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMember">数据成员类型。</typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyName">绑定的属性。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMemberExpression">数据成员表达式。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TSource, TMember>(this Control control, string propertyName, TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression)
        {
            var member = dataMemberExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return Binding(control, propertyName, dataSource, member.Member.Name);
        }
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TControl">控件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyNameExpression">绑定的成员表达式。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dateMember">绑定的数据成员。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TControl, TProperty>(this TControl control, Expression<Func<TControl, TProperty>> propertyNameExpression, object dataSource, string dataMember) where TControl : Control
        {
            var property = propertyNameExpression.Body as MemberExpression;
            if (property.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{property.Member.Name} is not a property.");
            }
            return Binding(control, property.Member.Name, dataSource, dataMember);
        }
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TControl">控件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMember">数据成员类型。</typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyNameExpression">绑定的成员表达式。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMemberExpression">数据成员表达式。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.Binding>"/> 新实例。</returns>
        public static Binding Binding<TControl, TProperty, TSource, TMember>(this TControl control, Expression<Func<TControl, TProperty>> propertyNameExpression, TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression) where TControl : Control
        {
            var property = propertyNameExpression.Body as MemberExpression;
            if (property.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{property.Member.Name} is not a property.");
            }
            var member = dataMemberExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return Binding(control, property.Member.Name, dataSource, member.Member.Name);
        }
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <param name="control">控件。</param>
        /// <param name="propertyName">绑定的属性。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dateMember">绑定的数据成员。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.DataBinding>"/> 新实例。</returns>
        public static DataBinding DataBinding(this Control control, string propertyName, object dataSource, string dataMember, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            var binding = new DataBinding(propertyName, dataSource, dataMember, converter, convertParameter, culture);
            control.DataBindings.Add(binding);
            return binding;
        }
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TMember"></typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyName">绑定的属性。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dataMemberExpression">数据成员表达式。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.DataBinding>"/> 新实例。</returns>
        public static DataBinding DataBinding<TSource, TMember>(this Control control, string propertyName, TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            var member = (dataMemberExpression.Body as MemberExpression).Member.Name;
            return DataBinding(control, propertyName, dataSource, member, converter, convertParameter, culture);
        }
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TControl">控件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyNameExpression">绑定的成员表达式。</param>
        /// <param name="dataSource">绑定的数据源。</param>
        /// <param name="dateMember">绑定的数据成员。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.DataBinding>"/> 新实例。</returns>
        public static DataBinding DataBinding<TControl, TProperty>(this TControl control, Expression<Func<TControl, TProperty>> propertyNameExpression, object dataSource, string dataMember, IValueConverter converter, object convertParameter = null, CultureInfo culture = null) where TControl : Control
        {
            var property = (propertyNameExpression.Body as MemberExpression).Member.Name;
            return DataBinding(control, property, dataSource, dataMember, converter, convertParameter, culture);
        }
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TControl">控件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMember">数据成员类型。</typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyNameExpression">绑定的成员表达式。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMemberExpression">数据成员表达式。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.DataBinding>"/> 新实例。</returns>
        public static DataBinding DataBinding<TControl, TProperty, TSource, TMember>(this TControl control, Expression<Func<TControl, TProperty>> propertyNameExpression, TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression, IValueConverter converter, object convertParameter = null, CultureInfo culture = null) where TControl : Control
        {
            var property = (propertyNameExpression.Body as MemberExpression).Member.Name;
            var member = (dataMemberExpression.Body as MemberExpression).Member.Name;
            return DataBinding(control, property, dataSource, member, converter, convertParameter, culture);
        }
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <param name="control">控件。</param>
        /// <param name="propertyName">绑定的属性。</param> 
        /// <param name="dataMembers">绑定的数据成员。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.MultiDataBinding>"/> 新实例。</returns>
        public static MultiDataBinding MultiDataBinding(this Control control, string propertyName, IEnumerable<DataSourceMemeber> dataMembers, IMultiValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            var binding = new MultiDataBinding(propertyName, dataMembers, converter, convertParameter, culture);
            control.DataBindings.Add(binding);
            return binding;
        }
        /// <summary>
        /// 创建指定属性的绑定信息。
        /// </summary>
        /// <typeparam name="TControl">控件类型。</typeparam>
        /// <typeparam name="TProperty">绑定的属性类型。</typeparam>
        /// <param name="control">控件。</param>
        /// <param name="propertyNameExpression">绑定的成员表达式。</param>
        /// <param name="dataMemberFactory">绑定成员创建方法。</param>
        /// <param name="converter">值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回 <see cref="System.Windows.Forms.MultiDataBinding>"/> 新实例。</returns>
        public static MultiDataBinding MultiDataBinding<TControl, TProperty>(this TControl control, Expression<Func<TControl, TProperty>> propertyNameExpression, Func<IEnumerable<DataSourceMemeber>> dataMemberFactory, IMultiValueConverter converter, object convertParameter = null, CultureInfo culture = null) where TControl : Control
        {
            var property = propertyNameExpression.Body as MemberExpression;
            if (property.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{property.Member.Name} is not a property.");
            }
            return MultiDataBinding(control, property.Member.Name, dataMemberFactory(), converter, convertParameter, culture);
        }
    }
}
