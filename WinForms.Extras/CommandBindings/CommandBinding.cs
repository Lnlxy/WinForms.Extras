namespace System.Windows.Forms
{
    /// <summary>
    /// 命令绑定。
    /// </summary>
    class CommandBinding
    {
        private readonly ICommand _command;
        private readonly CommandTarget _target;
        private readonly IValueObject _commandParameter;
        internal CommandBinding(ICommand command, CommandTarget target) : this(command, target, null)
        {
        }
        internal CommandBinding(ICommand command, CommandTarget target, IValueObject commandParameter)
        {
            _target = target;
            _command = command;
            _commandParameter = commandParameter;
            target.DoEvent(OnTargetEventHandle);
            if (commandParameter != null)
            {
                commandParameter.ValueChanged += OnVlaueChanged;
            }
        }

        private void OnTargetEventHandle(object sender, EventArgs e)
        {
            _command.Execute(_commandParameter?.Value);
        } 

        private void OnVlaueChanged(object sender, EventArgs e)
        {
            _target.UpdateState(_command.CanExecute(_commandParameter?.Value));
        }
    }
}
