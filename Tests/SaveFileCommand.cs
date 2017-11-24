using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tests
{
    class SaveFileCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            var doc = (parameter as Document);
            return !doc?.IsSaved ?? true;
        }

        public void Execute(object parameter)
        {
            (parameter as Document).Save();
        }
    }
}
