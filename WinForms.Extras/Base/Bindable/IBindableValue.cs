// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="IBindableValue.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel;

namespace System.Windows.Forms
{
    #region Interfaces

    /// <summary>
    /// 定义数据绑定项。
    /// </summary>
    public interface IBindableValue : IValueObject, INotifyPropertyChanged
    {
    }

    #endregion
}
