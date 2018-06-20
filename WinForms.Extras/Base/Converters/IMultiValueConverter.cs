// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="IMultiValueConverter.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Globalization;

namespace System.Windows.Forms
{
    #region Interfaces

    public interface IMultiValueConverter
    {
        #region Methods

        /// <summary>
        /// 将源值转换为绑定源的值。数据绑定引擎在将值从绑定源传播给绑定目标时，调用此方法。
        /// </summary>
        /// <param name="values">System.Windows.Data.MultiBinding 中源绑定生成的值的数组。值 System.Windows.DependencyProperty.UnsetValue 表示源绑定没有要提供以进行转换的值。</param>
        /// <param name="targetType">绑定目标属性的类型。</param>
        /// <param name="parameter"> 要使用的转换器参数。</param>
        /// <param name="culture">要用在转换器中的区域性。</param>
        /// <returns>转换后的值。如果该方法返回 null，则使用有效的 null 值。</returns>
        object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// 将绑定目标值转换为源绑定值。
        /// </summary>
        /// <param name="value">绑定目标生成的值。</param>
        /// <param name="targetTypes">要转换到的类型数组。数组长度指示为要返回的方法所建议的值的数量与类型。</param>
        /// <param name="parameter">要使用的转换器参数。</param>
        /// <param name="culture">要用在转换器中的区域性。</param>
        /// <returns>从目标值转换回源值的值的数组。</returns>
        object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);

        #endregion
    }

    #endregion
}
