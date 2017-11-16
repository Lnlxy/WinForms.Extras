using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tests
{
    class NewFileCommnd : ICommand
    {
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
    }
}
