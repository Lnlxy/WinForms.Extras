namespace System.Windows.Froms.Commands
{
    /// <summary>
    /// 提供由系统调度执行的命令。
    /// </summary>
    public sealed class RelayCommand : Command
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;

        public override event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        public override void Execute(object parameter)
        {
            if (CanExecute(parameter))
                _execute(parameter);
        }

    }
}
