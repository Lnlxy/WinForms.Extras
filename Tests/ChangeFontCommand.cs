using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tests
{
    class ChangeFontCommand : ICommand
    {
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
    }
}
