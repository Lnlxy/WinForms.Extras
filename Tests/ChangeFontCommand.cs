// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="ChangeFontCommand.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Windows.Forms;

namespace Tests
{
    internal class ChangeFontCommand : ICommand
    {
        #region Methods

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            NotePadSettings settings = (NotePadSettings)parameter;
            using (FontDialog dialog = new FontDialog())
            {
                dialog.Font = settings.Font;
                var result = dialog.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }
                settings.Font = dialog.Font;
            }
        }

        #endregion
    }
}
