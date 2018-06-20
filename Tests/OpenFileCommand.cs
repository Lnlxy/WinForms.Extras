// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="OpenFileCommand.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Windows.Forms;

namespace Tests
{
    internal class OpenFileCommand : ICommand
    {
        #region Methods

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var notePad = (NotePad)parameter;
            if (notePad.Document == null)
            {
                MessageBox.Show(notePad, "未创建任何文本文件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "所有文件(*.*)|*.*";
                dialog.Multiselect = false;
                if (dialog.ShowDialog(notePad) == DialogResult.OK)
                {
                    notePad.Document = Document.Open(dialog.FileName);
                }
            }
        }

        #endregion
    }
}
