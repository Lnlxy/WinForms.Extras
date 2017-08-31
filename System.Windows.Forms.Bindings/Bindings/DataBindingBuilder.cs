using System.Globalization;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 提供构建 <see cref="DataBinding"/> 实例的方法。
    /// </summary>
    public class DataBindingBuilder
    {
        private readonly Control _control;
        private readonly string _controlPropertyName;
        private object _dataSource;
        private string _dataMember;
        private object _dataSourceNullValue;
        private ControlUpdateMode _controlUpdateMode = ControlUpdateMode.Never;
        private DataSourceUpdateMode _dataSourceUpdateMode = DataSourceUpdateMode.Never;
        private IFormatProvider _formatInfo;
        private string _formatString;
        private bool _formattingEnabled;
        private object _convertParameter;
        private IValueConverter _converter;
        private CultureInfo _culture;

        /// <summary>
        /// 初始化 <see cref="DataBindingBuilder"/> 新实例。
        /// </summary>
        /// <param name="control">控件。</param>
        /// <param name="controlPropertyName">属性。</param>
        public DataBindingBuilder(Control control, string controlPropertyName)
        {
            _control = control;
            _controlPropertyName = controlPropertyName;
        }

        /// <summary>
        /// 设置绑定数据源和成员名称。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMemeber">成员类型。</typeparam>
        /// <param name="dataSource">数据源。</param>
        /// <param name="dataMemeberExpression">成员表达式。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetDataSourceAndDataMemeber<TSource, TMemeber>(TSource dataSource, Expression<Func<TSource, TMemeber>> dataMemeberExpression)
        {
            var member = dataMemeberExpression.Body as MemberExpression;
            if (member.Member.MemberType != Reflection.MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return SetDataSource(dataSource).SetDataMember(member.Member.Name);
        }

        /// <summary>
        /// 设置绑定数据源。
        /// </summary>
        /// <param name="dataSource">数据源。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetDataSource(object dataSource)
        {
            _dataSource = dataSource;
            return this;
        }

        /// <summary>
        /// 设置绑定成员。
        /// </summary>
        /// <param name="dataMember">成员名称。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetDataMember(string dataMember)
        {
            _dataMember = dataMember;
            return this;
        }

        /// <summary>
        /// 设置控件更新模式。
        /// </summary>
        /// <param name="controlUpdateMode">更新模式。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetControlUpdateMode(ControlUpdateMode controlUpdateMode)
        {
            _controlUpdateMode = controlUpdateMode;
            return this;
        }

        /// <summary>
        /// 设置数据源更新模式。
        /// </summary>
        /// <param name="dataSourceUpdateMode">更新模式。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetDataSourceUpdateMode(DataSourceUpdateMode dataSourceUpdateMode)
        {
            _dataSourceUpdateMode = dataSourceUpdateMode;
            return this;
        }
        /// <summary>
        /// 设置数据源为空时的值。
        /// </summary>
        /// <param name="value">默认值。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder DataSourceNullValue(object value)
        {
            _dataSourceNullValue = value;
            return this;
        }

        /// <summary>
        /// 设置格式化信息。
        /// </summary>
        /// <param name="formatString">格式。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetFormatString(string formatString)
        {
            _formatString = formatString;
            return this;
        }

        /// <summary>
        /// 设置格式化信息。
        /// </summary>
        /// <param name="formatInfo">格式化信息。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetFormatInfo(IFormatProvider formatInfo)
        {
            _formatInfo = formatInfo;
            return this;
        }
        /// <summary>
        /// 设置是否对控件属性数据应用类型转换和格式设置。
        /// </summary>
        /// <param name="formattingEnabled">是否设置。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetFormattingEnabled(bool formattingEnabled)
        {
            _formattingEnabled = formattingEnabled;
            return this;
        }

        /// <summary>
        /// 设置值转换区域信息。
        /// </summary>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetCulture(CultureInfo culture)
        {
            _culture = culture;
            return this;
        }

        /// <summary>
        /// 设置值转换器。
        /// </summary>
        /// <param name="converter">转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">转换区域信息。</param>
        /// <returns>返回设置完成后的 <see cref="DataBindingBuilder"/>。</returns>
        public DataBindingBuilder SetConverter(IValueConverter converter, object convertParameter)
        {
            _converter = converter;
            _convertParameter = convertParameter;
            return this;
        }

        /// <summary>
        /// 返回构建绑定到控件后的绑定信息。
        /// </summary>
        /// <returns></returns>
        public DataBinding Build()
        {
            var db = new DataBinding(_controlPropertyName, _dataSource, _dataMember)
                .SetControlUpdateMode(_controlUpdateMode)
                .SetDataSourceUpdateMode(_dataSourceUpdateMode)
                .SetDataSourceNullValue(_dataSourceNullValue)
                .SetFormattingEnabled(_formattingEnabled)
                .SetFormatInfo(_formatInfo)
                .SetFormatString(_formatString)
                .SetConverter(_converter, _convertParameter)
                .SetCulture(_culture);
            _control.DataBindings.Add(db);
            return db;
        }
    }
}
