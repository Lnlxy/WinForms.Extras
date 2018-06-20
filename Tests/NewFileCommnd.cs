// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="NewFileCommnd.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Windows.Forms;

namespace Tests
{
    internal class NewFileCommnd : ICommand
    {
        #region Methods

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var notePad = (NotePad)parameter;
            if (!notePad.Document.IsSaved)
            {
                var result = MessageBox.Show(notePad, "尚未保存文件，是否要先保存文件？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return;
                }
                else if (result == DialogResult.Yes)
                {
                    notePad.Document.Save();
                }
            }
            notePad.Document = new Document();
        }

        #endregion
    }
}
