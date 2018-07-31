// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="DataBinding.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Globalization;

namespace System.Windows.Forms
{
    /// <summary>
    /// 提供转换数据源成员数据后绑定到目标属性绑定信息。
    /// </summary>
    internal class DataBinding : Binding
    {
        #region Constructors

        /// <summary>
        /// 初始化 <see cref="DataBinding" /> 新实例。
        /// </summary>
        /// <param name="propertyName">绑定的属性名称。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMember">数据成员。</param>
        /// <param name="converter">转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">区域信息。</param>
        public DataBinding(string propertyName, object dataSource, string dataMember, IValueConverter converter, object convertParameter, CultureInfo culture) : base(propertyName, dataSource, dataMember)
        {
            Converter = converter;
            ConvertParameter = convertParameter;
            Culture = culture;
        }

        /// <summary>
        /// 初始化 <see cref="DataBinding" />新实例。
        /// </summary>
        /// <param name="propertyName">绑定的属性名称。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMember">数据成员。</param>
        /// <param name="valueConverter">转换器。</param>
        public DataBinding(string propertyName, object dataSource, string dataMember, IValueConverter valueConverter)
            : this(propertyName, dataSource, dataMember, valueConverter, null)
        {
        }

        /// <summary>
        /// 初始化 <see cref="DataBinding" /> 新实例。
        /// </summary>
        /// <param name="propertyName">绑定的属性名称。</param>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMember">数据成员。</param>
        /// <param name="valueConverter">转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        public DataBinding(string propertyName, object dataSource, string dataMember, IValueConverter valueConverter, object convertParameter)
            : this(propertyName, dataSource, dataMember, valueConverter, convertParameter, CultureInfo.CurrentCulture)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// 获取一个值，该值表示此绑定的值转换器。
        /// </summary>
        public IValueConverter Converter { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示转换时，使用的参数信息。
        /// </summary>
        public object ConvertParameter { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示转换时的区域信息。
        /// </summary>
        public CultureInfo Culture { get; private set; }

        #endregion

        #region Methods

        protected override void OnFormat(ConvertEventArgs cevent)
        {
            cevent.Value = Converter.Convert(cevent.Value, cevent.DesiredType, ConvertParameter, Culture);
        }

        protected override void OnParse(ConvertEventArgs cevent)
        {
            cevent.Value = Converter.ConvertBack(cevent.Value, cevent.DesiredType, ConvertParameter, Culture);
        }

        #endregion
    }
}
