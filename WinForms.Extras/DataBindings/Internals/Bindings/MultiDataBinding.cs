// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="MultiDataBinding.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Globalization;

namespace System.Windows.Forms
{
    /// <summary>
    /// 多值绑定。
    /// </summary>
    internal class MultiDataBinding : Binding
    {
        #region Fields

        private readonly Type[] _types = null;

        #endregion

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="MultiDataBinding"/> 新实例。
        /// </summary>
        /// <param name="propertyName">绑定的属性名称。</param>
        /// <param name="parameters">绑定源。</param>
        /// <param name="converter">转换器。</param>
        public MultiDataBinding(string propertyName, MultiBindableValue item, IMultiValueConverter converter) : this(propertyName, item, converter, null, null)
        {
        }

        /// <summary>
        /// 初始化 <see cref="MultiDataBinding"/> 新实例。
        /// </summary>
        /// <param name="propertyName">绑定的属性名称。</param>
        /// <param name="parameters">绑定源。</param>
        /// <param name="converter">转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        public MultiDataBinding(string propertyName, MultiBindableValue item, IMultiValueConverter converter, object convertParameter) : this(propertyName, item, converter, convertParameter, null)
        {
        }

        /// <summary>
        /// 初始化 <see cref="MultiDataBinding"/> 新实例。
        /// </summary>
        /// <param name="propertyName">绑定的属性名称。</param>
        /// <param name="parameters">绑定源。</param>
        /// <param name="converter">转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域。</param>
        public MultiDataBinding(string propertyName, MultiBindableValue item, IMultiValueConverter converter, object convertParameter, CultureInfo culture) : base(propertyName, item, "Value")
        {
            _types = item.ValueTypes;
            Converter = converter;
            ConvertParameter = convertParameter;
            Culture = culture;
        }

        MultiDataBinding(string propertyName, object dataSource, string dataMember) : base(propertyName, dataSource, dataMember)
        {
        }

        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled) : base(propertyName, dataSource, dataMember, formattingEnabled)
        {
        }

        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode) : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode)
        {
        }

        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue) : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue)
        {
        }

        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue, string formatString) : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue, formatString)
        {
        }

        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue, string formatString, IFormatProvider formatInfo) : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue, formatString, formatInfo)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// 获取一个值，该值表示转换器。
        /// </summary>
        public IMultiValueConverter Converter { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示转换时的参数。
        /// </summary>
        public object ConvertParameter { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示转换区域信息。
        /// </summary>
        public CultureInfo Culture { get; private set; }

        #endregion

        #region Methods

        protected override void OnFormat(ConvertEventArgs cevent)
        {
            var values = (object[])cevent.Value;
            cevent.Value = Converter.Convert(values, cevent.DesiredType, ConvertParameter, Culture);
        }

        protected override void OnParse(ConvertEventArgs cevent)
        {
            var values = Converter.ConvertBack(cevent.Value, _types, ConvertParameter, Culture);
            cevent.Value = values;
        }

        #endregion
    }
}
