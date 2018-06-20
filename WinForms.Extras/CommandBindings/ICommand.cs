// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="ICommand.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

namespace System.Windows.Forms
{
    #region Interfaces

    /// <summary>
    /// 定义一个命令体，提供执行方法。
    /// </summary>
    public interface ICommand
    {
        #region Methods

        /// <summary>
        /// 确定表示该命令是否能被执行。
        /// </summary>
        /// <param name="parameter">参数。</param>
        /// <returns>返回一个值，该值表示命令是否执行。</returns>
        bool CanExecute(object parameter);

        /// <summary>
        /// 执行命令。
        /// </summary>
        /// <param name="parameter">参数。</param>
        void Execute(object parameter);

        #endregion
    }

    #endregion
}
