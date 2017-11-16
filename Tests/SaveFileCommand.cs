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
            return !(bool)((object[])parameter)[1];
        }

        public void Execute(object parameter)
        {
            ((Document)((object[])parameter)[0]).Save();
        }
    }
}
