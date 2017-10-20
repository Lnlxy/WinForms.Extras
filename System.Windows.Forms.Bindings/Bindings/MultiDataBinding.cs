// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 10-20-2017
//
// ***********************************************************************
// <copyright file="multidatabinding.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2017 (c) Park Plus Inc. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace System.Windows.Forms
{
    /// <summary>
    /// 多值绑定。
    /// </summary>
    public class MultiDataBinding : Binding
    {
        private readonly List<DataSourceMemeber> _members;

        /// <summary>
        /// 初始化 <see cref="MultiDataBinding"/> 新实例。
        /// </summary>
        /// <param name="propertyName">绑定的属性名称。</param>
        /// <param name="parameters">绑定源。</param>
        /// <param name="converter">转换器。</param>
        public MultiDataBinding(string propertyName, IEnumerable<DataSourceMemeber> parameters, IMultiValueConverter converter) : this(propertyName, parameters, converter, null, null)
        {
        }

        /// <summary>
        /// 初始化 <see cref="MultiDataBinding"/> 新实例。
        /// </summary>
        /// <param name="propertyName">绑定的属性名称。</param>
        /// <param name="parameters">绑定源。</param>
        /// <param name="converter">转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        public MultiDataBinding(string propertyName, IEnumerable<DataSourceMemeber> parameters, IMultiValueConverter converter, object convertParameter) : this(propertyName, parameters, converter, convertParameter, null)
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
        public MultiDataBinding(string propertyName, IEnumerable<DataSourceMemeber> parameters, IMultiValueConverter converter, object convertParameter, CultureInfo culture) : base(propertyName, parameters.First().DataSource, parameters.First().DateMember)
        {
            Converter = converter;
            ConvertParameter = convertParameter;
            Culture = culture;
            _members = new List<DataSourceMemeber>(parameters);
            _members.Skip(1).ToList().ForEach(i => i.DataMemberValueChanged += ParameterValueChanged);
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

        /// <summary>
        /// 获取一个值，该值表示绑定源。
        /// </summary>
        public IEnumerable<DataSourceMemeber> SourceMemebers => _members.AsReadOnly();

        protected override void OnFormat(ConvertEventArgs cevent)
        {
            var values = _members.ConvertAll(i => i.GetDataMemberValue()).ToArray();
            cevent.Value = Converter.Convert(values, cevent.DesiredType, ConvertParameter, Culture);
        }

        protected override void OnParse(ConvertEventArgs cevent)
        {
            var types = _members.ConvertAll(i => i.DataMemberType).ToArray();
            var values = Converter.ConvertBack(cevent.Value, types, ConvertParameter, Culture);
            for (int i = 0; i < _members.Count; i++)
            {
                _members[i].SetDataMemberValue(values[i]);
            }
        }

        private void ParameterValueChanged(object sender, EventArgs e)
        {
            ReadValue();
        }
    }
}
