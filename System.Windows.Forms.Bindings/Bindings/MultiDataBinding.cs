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
        public IMultiValueConverter Converter { get; set; }
        public object ConvertParameter { get; set; }
        public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;
        public IEnumerable<DataSourceMemeber> SourceMemebers => _members.AsReadOnly();
        #region 隐藏的
        MultiDataBinding(string propertyName, object dataSource, string dataMember) : base(propertyName, dataSource, dataMember) { }
        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled) : base(propertyName, dataSource, dataMember, formattingEnabled) { }
        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode) : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode) { }
        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue) : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue) { }
        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue, string formatString) : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue, formatString) { }
        MultiDataBinding(string propertyName, object dataSource, string dataMember, bool formattingEnabled, DataSourceUpdateMode dataSourceUpdateMode, object nullValue, string formatString, IFormatProvider formatInfo) : base(propertyName, dataSource, dataMember, formattingEnabled, dataSourceUpdateMode, nullValue, formatString, formatInfo) { }
        #endregion
        public MultiDataBinding(string propertyName, IEnumerable<DataSourceMemeber> parameters) : base(propertyName, parameters.First().DataSource, parameters.First().DateMember)
        {
            _members = new List<DataSourceMemeber>(parameters);
            _members.ForEach(i => i.DataMemberValueChanged += ParameterValueChanged);
        }
        
        /// <summary>
        /// 设置转换器。
        /// </summary> 
        /// <param name="converter">转换器。</param>
        /// <param name="convertParameter">转换时使用的参数。</param>
        /// <returns>返回设置完成后的实例。</returns>
        public MultiDataBinding SetConverter(IMultiValueConverter converter, object convertParameter)
        {
            Converter = converter;
            ConvertParameter = convertParameter;
            return this;
        }

        /// <summary>
        /// 设置转换时指定的区域信息。
        /// </summary>
        /// <param name="culture">区域。</param>
        /// <returns>返回设置完成后的实例。</returns>
        public MultiDataBinding SetCulture(CultureInfo culture)
        {
            Culture = culture;
            return this;
        }


        protected override void OnFormat(ConvertEventArgs cevent)
        {
            var values = _members.ConvertAll(i => i.GetDataMemberValue()).ToArray();
            if (Converter != null)
            {
                cevent.Value = Converter.Convert(values, cevent.DesiredType, ConvertParameter, Culture);
            }
            else
            {
                cevent.Value = values;
            }
            if (FormattingEnabled && string.IsNullOrEmpty(FormatString))
            {
                if (FormatInfo != null)
                {
                    cevent.Value = string.Format(FormatInfo, FormatString, cevent.Value);
                }
                else
                {

                    cevent.Value = string.Format(FormatString, cevent.Value);
                }
            }
            base.OnFormat(cevent);
        }
        protected override void OnParse(ConvertEventArgs cevent)
        {
            if (Converter != null)
            {
                var types = _members.ConvertAll(i => i.DataMemberType).ToArray();
                var values = Converter.ConvertBack(cevent.Value, types, ConvertParameter, Culture);
                for (int i = 0; i < _members.Count; i++)
                {
                    _members[i].SetDataMemberValue(values[i]);
                }
            }
            else
            {
                cevent.Value = Convert.ChangeType(cevent.Value, cevent.DesiredType, Culture);
            }
            base.OnParse(cevent);
        }
        private void ParameterValueChanged(object sender, EventArgs e)
        {
            ReadValue();
        }
    }
}
