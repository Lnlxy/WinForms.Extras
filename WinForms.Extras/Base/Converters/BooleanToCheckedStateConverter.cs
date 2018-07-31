// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="BooleanToCheckedStateConverter.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Globalization;

namespace System.Windows.Forms
{
    /// <summary>
    /// 将 <see cref="bool"/> 转换为 <see cref="CheckState"/> 值。
    /// </summary>
    public sealed class BooleanToCheckedStateConverter : IValueConverter
    {
        #region Methods

        /// <summary>
        /// 转换。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool?)
            {
                var decision = (bool?)value;
                if (!decision.HasValue)
                {
                    return CheckState.Indeterminate;
                }
                else if (decision.Value)
                {
                    return CheckState.Checked;
                }
                {
                    return CheckState.Unchecked;
                }
            }
            else if (!(value is bool))
            {
                throw new Exception();
            }
            else
            {
                var decision = (bool)value;
                if (decision)
                {
                    return CheckState.Checked;
                }
                {
                    return CheckState.Unchecked;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (CheckState)value;
            if (state == CheckState.Indeterminate)
            {
                if (typeof(bool?).IsAssignableFrom(targetType))
                {
                    return null;
                }
                else
                {
                    return false;
                }
            }
            else if (state == CheckState.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
    }
}
