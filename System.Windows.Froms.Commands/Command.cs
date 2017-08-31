using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Froms.Commands
{
    public abstract class Command : ICommand
    {
        public virtual event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
        internal protected void RaiseCanExecuteChanged(EventArgs args)
        {
            CanExecuteChanged?.Invoke(this, args);
        }
    }
}
