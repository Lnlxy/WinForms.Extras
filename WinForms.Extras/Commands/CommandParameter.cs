namespace System.Windows.Forms
{
    using System.Windows.Forms.Internals;

    /// <summary>
    /// 表示命令参数。
    /// </summary>
    public class CommandParameter
    {
        private readonly PropertyDescriptor _property;

        public Type DataSourceType { get => _property.ReflectedType; }

        /// <summary>
        /// 初始化 <see cref="CommandParameter"/> 新实例。
        /// </summary>
        /// <param name="source">数据源。</param>
        /// <param name="propertyName">属性名称。</param>
        public CommandParameter(object source, string propertyName)
        {
            Source = source;
            _property = SourceTypeDescriptor.GetProperty(source, propertyName);
            _property.AddValueChanged(null, OnValueCHanged);
            ParameterName = propertyName;
        }

        public CommandParameter(Type sourceType, string propertyName)
        {
            _property = SourceTypeDescriptor.GetProperty(sourceType, propertyName);
            _property.AddValueChanged(null, OnValueCHanged);
            ParameterName = propertyName;
        }

        /// <summary>
        /// 当参数值发生改变时，发生。
        /// </summary>
        public event EventHandler ParameterValueChanged;

        /// <summary>
        /// 获取一个值，该值表示参数名称。
        /// </summary>
        public string ParameterName { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示参数值。
        /// </summary>
        public object ParameterValue => GetParameterValue();

        /// <summary>
        /// 获取一个值，该值表示数据源。
        /// </summary>
        public Object Source { get; private set; }

        private object GetParameterValue()
        {
            return _property.GetValue(Source);
        }

        private void OnValueCHanged(object sender, EventArgs e)
        {
            ParameterValueChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
