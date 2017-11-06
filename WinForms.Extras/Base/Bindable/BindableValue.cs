using System.ComponentModel;
using System.Windows.Forms.Internals;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义数据绑定项。
    /// </summary>
    public class BindableValue : IBindableValue
    {
        private readonly object _dataSource = null;

        private readonly SourcePropertyDescriptor _property;

        public BindableValue(object dataSource, string propertyName)
        {
            _dataSource = dataSource;
            PropertyName = propertyName;
            _property = SourceTypeDescriptor.GetProperty(dataSource, propertyName);
            _property.AddValueChanged(_dataSource, OnValueChanged);
        }

        public BindableValue(Type dataSourceType, string propertyName)
        {
            PropertyName = propertyName;
            _property = SourceTypeDescriptor.GetProperty(dataSourceType, propertyName);
            _property.AddValueChanged(_dataSource, OnValueChanged);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ValueChanged;

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
        public Type Type => _property.PropertyType;

        public object Value { get => _property.GetValue(_dataSource); set => _property.SetValue(_dataSource, value); }

        public override string ToString()
        {
            return $"{{SourceType:{DataSourceType}, PropertyName:{PropertyName}}}";
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }
    }
}
