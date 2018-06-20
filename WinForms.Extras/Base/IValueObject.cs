// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="IValueObject.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

namespace System.Windows.Forms
{
    #region Interfaces

    /// <summary>
    /// 定义一个值对象，提供值改变时的事件通知。
    /// </summary>
    public interface IValueObject
    {
        #region Events

        /// <summary>
        /// 当值改变时，发生。
        /// </summary>
        event EventHandler ValueChanged;

        #endregion

        #region Properties

        Type Type { get; }

        /// <summary>
        /// 获取后设置一个值，该值表示此实例的值。
        /// </summary>
        object Value { get; set; }

        #endregion
    }

    #endregion
}
