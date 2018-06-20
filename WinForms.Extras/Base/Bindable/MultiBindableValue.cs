// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="MultiBindableValue.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义多值绑定关系。
    /// </summary>
    public class MultiBindableValue : IBindableValue
    {
        #region Fields

        private readonly List<IValueObject> _items = new List<IValueObject>();

        #endregion

        #region Constructors

        public MultiBindableValue(IEnumerable<IValueObject> items)
        {
            foreach (var item in items)
            {
                item.ValueChanged += OnValueChanged;
            }
            _items.AddRange(items);
        }

        public MultiBindableValue(IValueObject item1, IValueObject item2, params IValueObject[] items)
            : this(new List<IValueObject> { item1, item2 }.Concat(items).ToList())
        {
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ValueChanged;

        #endregion

        #region Properties

        public Type Type => typeof(object[]);

        public object[] Value { get => GetValue(); set => SetValue(value); }

        public Type[] ValueTypes { get => _items.Select(i => i.Type).ToArray(); }

        object IValueObject.Value { get => Value; set => Value = (object[])value; }

        #endregion

        #region Methods

        internal object[] GetValue()
        {
            return _items.Select(i => i.Value).ToArray();
        }

        internal void SetValue(object[] newValue)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Value = newValue[i];
            }
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }

        #endregion
    }
}
