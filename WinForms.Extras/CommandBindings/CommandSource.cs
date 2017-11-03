namespace System.Windows.Forms
{
    /// <summary>
    /// 包含命令和命令参数信息。
    /// </summary>
    public class CommandSource
    {
        /// <summary>
        /// 初始化 <see cref="CommandSource"/> 新实例。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <param name="parameter">参数。</param>
        public CommandSource(ICommand command, CommandParameter parameter)
        {
            Command = command;
            Parameter = parameter;
            if (parameter != null)
            {
                parameter.ParameterValueChanged += OnRequerySuggested;
            }
        }

        /// <summary>
        /// 当命令参数的值发生改变时，通知命令目标更改其状态。
        /// </summary>
        public event EventHandler RequerySuggested;

        /// <summary>
        /// 获取一个值，该值表示命令。
        /// </summary>
        public ICommand Command { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示命令参数。
        /// </summary>
        public CommandParameter Parameter { get; private set; }

        internal bool CanExecuteCommand()
        {
            return Command.CanExecute(Parameter?.ParameterValue);
        }

        internal void ExecuteCommand()
        {
            Command.Execute(Parameter?.ParameterValue);
        }

        private void OnRequerySuggested(object sender, EventArgs e)
        {
            RequerySuggested?.Invoke(this, e);
        }
    }
}
