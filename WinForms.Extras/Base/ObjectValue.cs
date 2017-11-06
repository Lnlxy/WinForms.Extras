﻿using System.Collections;
using System.Collections.Generic;

namespace System.Windows.Forms
{
    public sealed class ObjectValue : IObjectValue, IConvertible, IComparable<ObjectValue>, IComparable, IComparer, IComparer<ObjectValue>
    {
        private volatile object _value;

        public ObjectValue()
        {
        }

        public ObjectValue(object value)
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

        public int Compare(object x, object y)
        {
            return Comparer.Default.Compare(x, y);
        }

        public int Compare(ObjectValue x, ObjectValue y)
        {
            return x?.CompareTo(y) ?? 0;
        }

        public int CompareTo(object obj)
        {
            return Comparer.Default.Compare(_value, obj);
        }

        public int CompareTo(ObjectValue other)
        {
            return Comparer.Default.Compare(_value, other?._value);
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
            return $"{{{_value.ToString()}}}";
        }

        public string ToString(IFormatProvider provider)
        {
            return Convert.ToString(_value, provider);
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
