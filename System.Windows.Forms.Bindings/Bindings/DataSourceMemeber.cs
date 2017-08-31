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
        private readonly PropertyInfo _propertyInfo;

        public object DataSource { get; private set; }

        public string DateMember { get; private set; }

        public Type DataMemberType => _propertyInfo.PropertyType;

        public Object DataSourceNullValue { get; set; }

        public event EventHandler DataMemberValueChanged;

        public DataSourceMemeber(object dataSource, string dataMember)
        {
            DataSource = dataSource;
            DateMember = dataMember;
            _propertyInfo = DataSource.GetType().GetProperty(dataMember);
            if (dataSource is INotifyPropertyChanged)
            {
                ((INotifyPropertyChanged)dataSource).PropertyChanged += MultiDataBindingParameter_PropertyChanged;
            }
            if (DataSource is Control)
            {
                var eventDescriptor = TypeDescriptor.GetEvents(DataSource).OfType<EventDescriptor>().FirstOrDefault(i => i.Name.Contains(DateMember));
                if (eventDescriptor != null)
                {
                    eventDescriptor.AddEventHandler(dataSource, (EventHandler)OnMemberValueCHanged);
                }
            }
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

        public object GetMemberValue()
        {
            if (DataSource == null)
            {
                return DataSourceNullValue;
            }
            return _propertyInfo.GetValue(DataSource, null);
        }

        internal void SetMemberValue(object value)
        {
            if (DataSource != null)
            {
                _propertyInfo.SetValue(DataSource, Convert.ChangeType(value, DataMemberType), null);
            }
        }
    }
}
