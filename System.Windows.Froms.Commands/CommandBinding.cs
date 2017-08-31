using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;

namespace System.Windows.Froms.Commands
{
    public class CommandBinding
    {
        public IInputTarget InputTarget { get; private set; }

        public CommandSource CommandSource { get; private set; }

        public CommandBinding(IInputTarget inputTarget, CommandSource commandSource)
        {
            InputTarget = inputTarget;
            InputTarget.Click += InputTarget_Click;
            CommandSource = commandSource;
            CommandSource.RequerySuggested += CommandSource_RequerySuggested;
        }

        private void InputTarget_Click(object sender, EventArgs e)
        {
            CommandSource.Execute();
        }

        private void CommandSource_RequerySuggested(object sender, EventArgs e)
        {
            InputTarget.Enabled = CommandSource.CanExecute();
        } 
    }
}
