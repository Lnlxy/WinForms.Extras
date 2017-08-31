using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Froms.Commands
{
    public class CommandSource
    {
        public ICommand Command { get; private set; }

        public CommandParameter Parameter { get; private set; }

        public event EventHandler RequerySuggested;

        public CommandSource(ICommand command, CommandParameter parameter)
        {
            Command = command;
            command.CanExecuteChanged += OnRequerySuggested;
            Parameter = parameter;
            if (parameter != null)
            {
                parameter.ParameterValueChanged += OnRequerySuggested;
            }
        }

        private void OnRequerySuggested(object sender, EventArgs e)
        {
            RequerySuggested?.Invoke(this, e);
        }

        public void Execute()
        {
            Command.Execute(Parameter?.ParameterValue);
        }

        internal bool CanExecute()
        {
            return Command.CanExecute(Parameter?.ParameterValue);
        }
    }
}
