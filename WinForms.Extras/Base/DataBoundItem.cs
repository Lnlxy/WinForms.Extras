using System.Windows.Forms.Internals;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义数据绑定项。
    /// </summary>
    public class DataBoundItem : IDataBoundItem
    {
        private readonly SourcePropertyDescriptor _property;

        public DataBoundItem(object dataSource, string propertyName)
        {
            DataSource = dataSource;
            PropertyName = propertyName;
            _property = SourceTypeDescriptor.GetProperty(dataSource, propertyName);
        }

        /// <summary>
        /// 获取一个值，该值表示数据源。
        /// </summary>
        public object DataSource { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示数据源类型。
        /// </summary>
        public Type DataSourceType { get => _property.ReflectedType; }

        /// <summary>
        /// 获取一个值，该值表示绑定属性名称。
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示属性类型。
        /// </summary>
        public Type ValueType => _property.PropertyType;

        public object GetValue()
        {
            return _property.GetValue(DataSource);
        }

        public void SetValue(object value)
        {
            if (!_property.IsReadOnly)
            {
                _property.SetValue(DataSource, Convert.ChangeType(value, ValueType));
            }
        }

        public override string ToString()
        {
            return $"{{SourceType:{DataSourceType}, PropertyName:{PropertyName}}}";
        }

        public void ValueChangedCallback(EventHandler callback)
        {
            _property.AddValueChanged(DataSource, callback);
        }
    }
}
