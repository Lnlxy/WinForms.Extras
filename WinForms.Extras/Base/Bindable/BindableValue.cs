// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="BindableValue.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel;
using System.Linq;
using System.Windows.Forms.Internals;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义数据绑定项。
    /// </summary>
    public class BindableValue : IBindableValue
    {
        #region Fields

        private readonly SourcePropertyDescriptor _property;

        private BindableValue next = null;

        private BindableValue previous = null;

        #endregion

        #region Constructors

        /// <summary>
        /// 初始化 <see cref="BindableValue"/> 新实例。
        /// </summary>
        /// <param name="dataSource">数据源。</param>
        /// <param name="propertyName">属性名称。</param>
        public BindableValue(object dataSource, string propertyName)
        {
            var properties = propertyName.Split('.').ToList();

            if (properties.Count == 1)
            {
                DataSource = dataSource;
                _property = SourceTypeDescriptor.GetProperty(dataSource, properties.Last());
                _property.AddValueChanged(dataSource, OnValueChanged);
            }
            else
            {
                var root = new BindableValue(dataSource, properties[0]);
                for (int i = 1; i < properties.Count; i++)
                {
                    var pro = SourceTypeDescriptor.GetProperty(root.Type, properties[i]);
                    if (i == (properties.Count - 1))
                    {
                        DataSource = root.Value;
                        _property = pro;
                        _property.AddValueChanged(root.Value, OnValueChanged);
                        root.next = this;
                        previous = root;

                    }
                    else
                    {
                        root.next = new BindableValue(root.Value, pro);
                        root.next.previous = root;
                        root = root.next;
                    }
                }
            }
        }

        /// <summary>
        /// 初始化 <see cref="BindableValue"/> 新实例。
        /// </summary>
        /// <param name="dataSourceType">数据源类型。</param>
        /// <param name="propertyName">属性名称。</param>
        public BindableValue(Type dataSourceType, string propertyName)
        {
            var properties = propertyName.Split('.').ToList();

            if (properties.Count == 1)
            {
                DataSource = null;
                _property = SourceTypeDescriptor.GetProperty(dataSourceType, properties.Last());
                _property.AddValueChanged(null, OnValueChanged);
            }
            else
            {
                var root = new BindableValue(dataSourceType, properties[0]);
                for (int i = 1; i < properties.Count; i++)
                {
                    var pro = SourceTypeDescriptor.GetProperty(root.Type, properties[i]);
                    if (i == (properties.Count - 1))
                    {
                        DataSource = root.Value;
                        _property = pro;
                        _property.AddValueChanged(root.Value, OnValueChanged);
                    }
                    else
                    {

                        root.next = new BindableValue(root.Value, pro);
                        root.next.previous = root;
                        root = root.next;
                    }
                }
            }
        }

        private BindableValue(object dataSource, SourcePropertyDescriptor property)
        {
            DataSource = dataSource;
            _property = property;
            _property.AddValueChanged(dataSource, OnValueChanged);
        }

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        public event EventHandler ValueChanged;

        #endregion

        #region Properties

        public Object DataSource { get; private set; }

        public string PropertyName => _property.Name;

        public Type Type => _property.PropertyType;

        public object Value
        {
            get
            {
                {
                    if (previous == null)//没有深层次
                    {
                        return _property.GetValue(DataSource);
                    }
                    else
                    {
                        var dataSource = previous.Value;
                        if (dataSource != null)
                        {
                            return _property.GetValue(dataSource);
                        }
                        return null;
                    }
                }
            }
            set
            {
                if (previous == null)//没有深层次
                {
                    _property.SetValue(DataSource, value);
                }
                else
                {
                    var dataSource = previous.Value;
                    if (dataSource != null)
                    {
                        _property.SetValue(dataSource, value);
                    }
                }
            }
        }

        #endregion

        #region Methods

        private void OnValueChanged(object sender, EventArgs e)
        {
            if (next != null)
            {
                next._property.RemoveValueChanged(next.DataSource, OnValueChanged);
                next.DataSource = Value;
                next._property.AddValueChanged(next.DataSource, OnValueChanged);
                next.OnValueChanged(next.DataSource, e);
            }
            else
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Value"));
                ValueChanged?.Invoke(this, e);
            }
        }

        #endregion
    }
}
