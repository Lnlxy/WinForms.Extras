// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="SaveFileCommand.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Windows.Forms;

namespace Tests
{
    internal class SaveFileCommand : ICommand
    {
        #region Methods

        public bool CanExecute(object parameter)
        {
            return !(bool)((object[])parameter)[1];
        }

        public void Execute(object parameter)
        {
            ((Document)((object[])parameter)[0]).Save();
        }

        #endregion
    }
}
