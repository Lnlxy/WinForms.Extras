namespace System.Windows.Forms
{
    /// <summary>
    /// 提供执行指定方法的命令。
    /// </summary>
    public sealed class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;

        private readonly Action<object> _execute;

        /// <summary>
        /// 初始化 <see cref="RelayCommand"/> 新实例。
        /// </summary>
        /// <param name="execute">执行方法。</param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {
        }

        /// <summary>
        /// 初始化 <see cref="RelayCommand"/> 新实例。
        /// </summary>
        /// <param name="execute">执行方法。</param>
        /// <param name="canExecute">确定名称是否可被执行的方法。</param>
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// 确定表示该命令是否能被执行。
        /// </summary>
        /// <param name="parameter">参数。</param>
        /// <returns>返回一个值，该值表示命令是否执行。</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <summary>
        /// 执行命令。
        /// </summary>
        /// <param name="parameter">参数。</param>
        public void Execute(object parameter)
        {
            if (_canExecute?.Invoke(parameter) ?? true)
                _execute(parameter);
        }
    }

    /// <summary>
    /// 提供执行指定方法的命令。
    /// </summary>
    public sealed class RelayCommand<T> : ICommand
    {
        private readonly Func<T, bool> _canExecute;

        private readonly Action<T> _execute;

        /// <summary>
        /// 初始化 <see cref="RelayCommand{T}"/> 新实例。
        /// </summary>
        /// <param name="execute">执行方法。</param>
        public RelayCommand(Action<T> execute) : this(execute, null)
        {
        }

        /// <summary>
        /// 初始化 <see cref="RelayCommand{T}"/> 新实例。
        /// </summary>
        /// <param name="execute">执行方法。</param>
        /// <param name="canExecute">确定名称是否可被执行的方法。</param>
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// 确定表示该命令是否能被执行。
        /// </summary>
        /// <param name="parameter">参数。</param>
        /// <returns>返回一个值，该值表示命令是否执行。</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        /// <summary>
        /// 执行命令。
        /// </summary>
        /// <param name="parameter">参数。</param>
        public void Execute(object parameter)
        {
            if (_canExecute?.Invoke((T)parameter) ?? true)
                _execute((T)parameter);
        }
    }
}
