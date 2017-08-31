using System.ComponentModel;
using System.Reflection;
using System.Linq;
namespace System.Windows.Forms
{
    /// <summary>
    /// 定义多数据绑定的数据源参数信息。
    /// </summary>
    public class DataSourceMemeber
    {
        private readonly PropertyDescriptor _property;

        public object DataSource { get; private set; }

        public string DateMember { get; private set; }

        public Type DataMemberType => _property.PropertyType;

        public Object DataSourceNullValue { get; set; }

        public event EventHandler DataMemberValueChanged;

        public DataSourceMemeber(object dataSource, string dataMember)
        {
            DataSource = dataSource;
            DateMember = dataMember;
            _property = TypeDescriptor.GetProperties(dataSource).Find(DateMember, false);
            _property.AddValueChanged(dataSource, OnValueChanged);
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            DataMemberValueChanged?.Invoke(this, e);
        }

        private void OnMemberValueCHanged(object sender, EventArgs e)
        {
            DataMemberValueChanged?.Invoke(this, e);
        }

        private void MultiDataBindingParameter_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(DateMember))
            {
                DataMemberValueChanged?.Invoke(this, e);
            }
        }

        public object GetDataMemberValue()
        {
            if (DataSource == null)
            {
                return DataSourceNullValue;
            }
            return _property.GetValue(DataSource);
        }

        internal void SetDataMemberValue(object value)
        {
            if (DataSource != null && !_property.IsReadOnly)
            {
                _property.SetValue(DataSource, Convert.ChangeType(value, DataMemberType));
            }
        }
    }
}
