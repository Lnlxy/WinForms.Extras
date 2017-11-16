namespace System.Windows.Forms
{
    /// <summary>
    /// 定义一个值对象。
    /// </summary>
    public sealed class ValueObject : IValueObject, IConvertible, IFormattable, IEquatable<ValueObject>
    {
        private volatile object _value;

        public ValueObject()
        {
        }

        public ValueObject(object value)
        {
            _value = value;
        }

        public event EventHandler ValueChanged;

        public Type Type => _value?.GetType() ?? null;

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

        public TypeCode GetTypeCode()
        {
            return Type.GetTypeCode(_value?.GetType() ?? typeof(Nullable));
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(_value, provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(_value, provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(_value, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(_value, provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(_value, provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(_value, provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(_value, provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(_value, provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(_value, provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(_value, provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(_value, provider);
        }

        public override string ToString()
        {
            return _value.ToString();
        }

        public string ToString(IFormatProvider provider)
        {
            return Convert.ToString(_value, provider);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, format, _value);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(_value, conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(_value, provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(_value, provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(_value, provider);
        }

        bool IEquatable<ValueObject>.Equals(ValueObject other)
        {
            return _value?.Equals(other?._value) ?? false;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as ValueObject);
        }
        public override int GetHashCode()
        {
            return _value.GetHashCode();
        } 
        public static implicit operator ValueObject(string value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(short value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(int value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(long value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(ushort value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(uint value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(ulong value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(float value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(double value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(char value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(byte value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(sbyte value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(decimal value)
        {
            return new ValueObject(value);
        }
        public static implicit operator ValueObject(bool value)
        {
            return new ValueObject(value);
        }
    }
}
