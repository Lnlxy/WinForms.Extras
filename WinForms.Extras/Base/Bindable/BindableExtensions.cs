// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="BindableExtensions.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace System.Windows.Forms
{
    /// <summary>
    /// 功能拓展。
    /// </summary>
    public static class BindableExtensions
    {
        #region Methods

        /// <summary>
        /// 创建数据绑定新实例。
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <param name="dataSource"></param>
        /// <param name="propertyExpression"></param>
        /// <returns></returns>
        public static BindableValue CreateBindableValue<TSource, TProperty>(this TSource dataSource, Expression<Func<TSource, TProperty>> propertyExpression)
        {
            var member = propertyExpression.Body as MemberExpression;
            if (member.Member.MemberType != MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }

            return new BindableValue(dataSource, member.Member.Name);
        }

        /// <summary>
        /// 创建多值绑定实例。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TProperty">属性类型。</typeparam>
        /// <param name="dataSource">数据源。</param>
        /// <param name="expression1">表达式1。</param>
        /// <param name="expression2">表达式2。</param>
        /// <param name="expressions">表达式。</param>
        /// <returns></returns>
        public static MultiBindableValue CreateMultiBindableValue<TSource, TProperty>(this TSource dataSource, Expression<Func<TSource, TProperty>> expression1, Expression<Func<TSource, TProperty>> expression2, params Expression<Func<TSource, TProperty>>[] expressions)
        {
            var bindableValues = new List<IBindableValue>();
            bindableValues.Add(dataSource.CreateBindableValue(expression1));
            bindableValues.Add(dataSource.CreateBindableValue(expression2));
            foreach (var exp in expressions)
            {
                bindableValues.Add(dataSource.CreateBindableValue(exp));
            }
            return new MultiBindableValue(bindableValues);
        }

        #endregion
    }
}
