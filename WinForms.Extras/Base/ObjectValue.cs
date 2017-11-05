using System.Collections;
using System.Collections.Generic;

namespace System.Windows.Forms
{
    public sealed class ObjectValue : IObjectValue, IConvertible, IComparable<ObjectValue>, IComparable, IComparer, IComparer<ObjectValue>
    {
        public ObjectValue()
        {
        }

        public ObjectValue(object value)
        {
            Value = value;
        }

        public object Value { get; set; }

        public int Compare(object x, object y)
        {
            return Comparer.Default.Compare(x, y);
        }

        public int Compare(ObjectValue x, ObjectValue y)
        {
            return x?.CompareTo(y) ?? 0;
        }

        public int CompareTo(ObjectValue other)
        {
            return Comparer.Default.Compare(Value, other?.Value);
        }

        public int CompareTo(object obj)
        {
            return Comparer.Default.Compare(Value, obj);
        }

        public TypeCode GetTypeCode()
        {
            return Type.GetTypeCode(Value?.GetType() ?? typeof(Nullable));
        }

        public bool ToBoolean(IFormatProvider provider)
        {
            return Convert.ToBoolean(Value, provider);
        }

        public byte ToByte(IFormatProvider provider)
        {
            return Convert.ToByte(Value, provider);
        }

        public char ToChar(IFormatProvider provider)
        {
            return Convert.ToChar(Value, provider);
        }

        public DateTime ToDateTime(IFormatProvider provider)
        {
            return Convert.ToDateTime(Value, provider);
        }

        public decimal ToDecimal(IFormatProvider provider)
        {
            return Convert.ToDecimal(Value, provider);
        }

        public double ToDouble(IFormatProvider provider)
        {
            return Convert.ToDouble(Value, provider);
        }

        public short ToInt16(IFormatProvider provider)
        {
            return Convert.ToInt16(Value, provider);
        }

        public int ToInt32(IFormatProvider provider)
        {
            return Convert.ToInt32(Value, provider);
        }

        public long ToInt64(IFormatProvider provider)
        {
            return Convert.ToInt64(Value, provider);
        }

        public sbyte ToSByte(IFormatProvider provider)
        {
            return Convert.ToSByte(Value, provider);
        }

        public float ToSingle(IFormatProvider provider)
        {
            return Convert.ToSingle(Value, provider);
        }

        public override string ToString()
        {
            return $"{{{Value.ToString()}}}";
        }

        public string ToString(IFormatProvider provider)
        {
            return Convert.ToString(Value, provider);
        }

        public object ToType(Type conversionType, IFormatProvider provider)
        {
            return Convert.ChangeType(Value, conversionType, provider);
        }

        public ushort ToUInt16(IFormatProvider provider)
        {
            return Convert.ToUInt16(Value, provider);
        }

        public uint ToUInt32(IFormatProvider provider)
        {
            return Convert.ToUInt32(Value, provider);
        }

        public ulong ToUInt64(IFormatProvider provider)
        {
            return Convert.ToUInt64(Value, provider);
        }



        public static implicit operator ObjectValue(string value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(short value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(int value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(long value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(ushort value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(uint value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(ulong value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(float value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(double value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(char value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(byte value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(sbyte value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(decimal value)
        {
            return new ObjectValue(value);
        }
        public static implicit operator ObjectValue(bool value)
        {
            return new ObjectValue(value);
        }
    }
}
