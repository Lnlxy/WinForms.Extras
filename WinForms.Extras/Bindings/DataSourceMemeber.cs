namespace System.Windows.Forms
{
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Windows.Forms.Internals;

    /// <summary>
    /// 定义多数据绑定的数据源参数信息。
    /// </summary>
    public class DataSourceMemeber
    {
        private readonly PropertyDescriptor _property;
        public DataSourceMemeber(Type dataSoureType, string dataMember)
        {
            DateMember = dataMember;
            _property = SourceTypeDescriptor.GetProperty(dataSoureType, dataMember);
            _property.AddValueChanged(null, OnValueChanged);
        }
        public DataSourceMemeber(object dataSource, string dataMember)
        {
            DataSource = dataSource;
            DateMember = dataMember;
            _property = SourceTypeDescriptor.GetProperty(dataSource, dataMember);
            _property.AddValueChanged(dataSource, OnValueChanged);
        }

        public event EventHandler DataMemberValueChanged;

        public Type DataMemberType => _property.PropertyType;

        public object DataSource { get; private set; }

        public string DateMember { get; private set; }

        public object Value
        {
            get { return GetValue(); }
            set
            {
                SetValue(value);
            }
        }

        public static DataSourceMemeber Create<TSource, TMember>(TSource dataSource, Expression<Func<TSource, TMember>> dataMemberExpression)
        {
            var member = dataMemberExpression.Body as MemberExpression;
            if (member.Member.MemberType != MemberTypes.Property)
            {
                throw new InvalidOperationException($"{member.Member.Name} is not a property.");
            }
            return new DataSourceMemeber(dataSource, member.Member.Name);
        }


        public object GetValue()
        {
            return _property.GetValue(DataSource);
        }

        internal void SetValue(object value)
        {
            if (!_property.IsReadOnly)
            {
                _property.SetValue(DataSource, Convert.ChangeType(value, DataMemberType));
            }
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            DataMemberValueChanged?.Invoke(this, e);
        }
    }
}
