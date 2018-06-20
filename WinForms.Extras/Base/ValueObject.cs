// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="ValueObject.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义一个值对象。
    /// </summary>
    public sealed class ValueObject : IValueObject
    {
        #region Fields

        private volatile object _value;

        #endregion

        #region Constructors

        public ValueObject()
        {
        }

        public ValueObject(object value)
        {
            _value = value;
        }

        #endregion

        #region Events

        public event EventHandler ValueChanged;

        #endregion

        #region Properties

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

        #endregion

    }
}
