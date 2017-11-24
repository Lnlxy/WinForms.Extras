namespace System.Windows.Forms
{
    /// <summary>
    /// 定义一个存储值的对象。
    /// </summary>
    public sealed class ValueObject : IValueObject, IFormattable, IEquatable<ValueObject>
    {
        private volatile object _value;

        /// <summary>
        /// 初始化 <see cref="ValueObject"/> 新实例。
        /// </summary>
        public ValueObject()
        {
        }

        /// <summary>
        /// 初始化 <see cref="ValueObject"/> 新实例。
        /// </summary>
        /// <param name="value">值。</param>
        public ValueObject(object value)
        {
            _value = value;
        }

        /// <summary>
        /// 定义 <see cref="Value"/> 值发生改变时的处理方法。
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// 获取一个值，该值表示数据类型。
        /// </summary>
        public Type Type => _value?.GetType();

        /// <summary>
        /// 获取或设置一个值，该值表示值对象存储的值。
        /// </summary>
        public object Value
        {
            get => _value;
            set
            {
                if (!Equals(_value, _value))
                {
                    _value = value;
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 指示当前对象是否等于同一类型的另一个对象。
        /// </summary>
        /// <param name="obj">与此对象进行比较的对象。</param>
        /// <returns>如果当前对象等于 other 参数，则为 true；否则为 false。</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as ValueObject);
        }

        /// <summary>
        /// 指示当前对象是否等于同一类型的另一个对象。
        /// </summary>
        /// <param name="other">与此对象进行比较的对象。</param>
        /// <returns>如果当前对象等于 other 参数，则为 true；否则为 false。</returns>
        public bool Equals(ValueObject other)
        {
            return _value?.Equals(other?._value) ?? false;
        }

        /// <summary>
        /// 获取对象的Hash值。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        /// <summary>
        /// 格式化当前实例的值。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _value.ToString();
        }

        /// <summary>
        /// 使用指定的格式格式化当前实例的值。
        /// </summary>
        /// <param name="format">要使用的格式。- 或 -null 引用（Visual Basic 中为 Nothing）将使用为 System.IFormattable 实现的类型所定义的默认格式。</param>
        /// <param name="formatProvider">要用于设置值格式的提供程序。- 或 -null 引用（Visual Basic 中为 Nothing）将从操作系统的当前区域设置中获取数字格式信息。</param>
        /// <returns> 当前实例的值，以指定格式表示。</returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, format, _value);
        }


        /// <summary>
        /// 创建存储 <see cref="string"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(string value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="short"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(short value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="int"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(int value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="long"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(long value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="ushort"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(ushort value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="uint"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(uint value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="ulong"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(ulong value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="float"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(float value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="double"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(double value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="char"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(char value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="byte"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(byte value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="sbyte"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(sbyte value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="decimal"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(decimal value)
        {
            return new ValueObject(value);
        }
        /// <summary>
        /// 创建存储 <see cref="bool"/> 类型的值的对象。
        /// </summary>
        /// <param name="value">值</param>
        public static implicit operator ValueObject(bool value)
        {
            return new ValueObject(value);
        }
    }
}
