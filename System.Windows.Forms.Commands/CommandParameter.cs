using System.ComponentModel;

namespace System.Windows.Forms
{
    /// <summary>
    /// 表示命令参数。
    /// </summary>
    public class CommandParameter
    {
        private readonly PropertyDescriptor _property;

        /// <summary>
        /// 获取一个值，该值表示数据源。
        /// </summary>
        public Object Source { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示静态数据源类型。
        /// </summary>
        public Type StaticSourceType { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示参数名称。
        /// </summary>
        public string ParameterName { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示参数值。
        /// </summary>
        public object ParameterValue => GetParameterValue();

        /// <summary>
        /// 当参数值发生改变时，发生。
        /// </summary>
        public event EventHandler ParameterValueChanged;

        /// <summary>
        /// 初始化 <see cref="CommandParameter"/> 新实例。
        /// </summary>
        /// <param name="source">数据源。</param>
        /// <param name="parameterName">参数值。</param>
        public CommandParameter(object source, string parameterName)
        {
            _property = TypeDescriptor.GetProperties(source).Find(parameterName, false);
            if (_property == null)
            {
                throw new MemberAccessException($"Type:{source.GetType().FullName}, Property:{parameterName}");
            }
            _property.AddValueChanged(source, OnValueCHanged);
            Source = source;
            ParameterName = parameterName;
        }


        /// <summary>
        /// 初始化 <see cref="CommandParameter"/> 新实例。
        /// </summary>
        /// <param name="staticSourceType">静态数据源类型。。</param>
        /// <param name="parameterName">参数值。</param>
        public CommandParameter(Type staticSourceType, string parameterName)
        {
            _property = TypeDescriptor.GetProperties(staticSourceType).Find(parameterName, false);
            if (_property == null)
            {
                throw new MemberAccessException($"Type:{staticSourceType.FullName}, Property:{parameterName}");
            }
            _property.AddValueChanged(_property.GetValue(null), OnValueCHanged);
            StaticSourceType = staticSourceType;
            ParameterName = parameterName;
        }
        private void OnValueCHanged(object sender, EventArgs e)
        {
            ParameterValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private object GetParameterValue()
        {
            return _property.GetValue(Source);
        }
    }
}
