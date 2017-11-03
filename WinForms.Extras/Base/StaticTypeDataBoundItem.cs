using System.Windows.Forms.Internals;

namespace System.Windows.Forms
{
    public class StaticTypeDataBoundItem : IDataBoundItem
    {
        private readonly SourcePropertyDescriptor _property;

        public StaticTypeDataBoundItem(Type dataSoureType, string dataMember)
        {
            PropertyName = dataMember;
            _property = SourceTypeDescriptor.GetProperty(dataSoureType, dataMember);
        }

        /// <summary>
        /// 获取一个值，该值表示数据源类型。
        /// </summary>
        public Type DataSourceType { get => _property.ReflectedType; }

        /// <summary>
        /// 获取一个值，该值表示绑定属性名称。
        /// </summary>
        public string PropertyName { get; private set; }

        public object Value { get => GetValue(); set => SetValue(value); }

        /// <summary>
        /// 获取一个值，该值表示属性类型。
        /// </summary>
        public Type ValueType => _property.PropertyType;

        public object GetValue()
        {
            return _property.GetValue(null);
        }

        public void SetValue(object newValue)
        {
            if (!_property.IsReadOnly)
            {
                _property.SetValue(null, newValue);
            }

        }

        public void ValueChangedCallback(EventHandler callback)
        {
        }
    }
}
