using System.Globalization;

namespace System.Windows.Forms
{
    public class DataBinding : Binding
    {
        /// <summary>
        /// 获取或设置一个值，该值表示此绑定的值转换器。
        /// </summary>
        public IValueConverter Converter { get; set; }

        public object ConvertParameter { get; set; }

        public CultureInfo Culture { get; set; } = CultureInfo.CurrentCulture;

        public DataBinding(string propertyName, object dataSource, string dataMember) : base(propertyName, dataSource, dataMember)
        {

        }

        /// <summary>
        /// 设置转换器。
        /// </summary> 
        /// <param name="converter">转换器。</param>
        /// <param name="convertParameter">转换时使用的参数。</param>
        /// <returns>返回设置完成后的实例。</returns>
        public DataBinding SetConverter(IValueConverter converter, object convertParameter)
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
        public DataBinding SetCulture(CultureInfo culture)
        {
            Culture = culture;
            return this;
        }

        protected override void OnFormat(ConvertEventArgs cevent)
        {
            if (Converter != null)
            {
                cevent.Value = Converter.Convert(cevent.Value, cevent.DesiredType, ConvertParameter, Culture);
            }
            else
            {
                cevent.Value = Convert.ChangeType(cevent.Value, cevent.DesiredType, Culture);
            }
            //if (FormattingEnabled && !string.IsNullOrEmpty(FormatString))
            //{
            //    if (FormatInfo != null)
            //    {
            //        cevent.Value = string.Format(FormatInfo, FormatString, cevent.Value);
            //    }
            //    else
            //    {
            //        cevent.Value = string.Format(FormatString, cevent.Value);
            //    }
            //}
            base.OnFormat(cevent);
        }
        protected override void OnParse(ConvertEventArgs cevent)
        {
            if (Converter != null)
            {
                cevent.Value = Converter.ConvertBack(cevent.Value, cevent.DesiredType, ConvertParameter, Culture);
            }
            else
            {
                cevent.Value = Convert.ChangeType(cevent.Value, cevent.DesiredType, Culture);
            }
            base.OnParse(cevent);
        }
    }
}
