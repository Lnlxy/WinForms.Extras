using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Froms
{
    /// <summary>
    /// 包含命令和命令参数信息。
    /// </summary>
    public class CommandSource
    {
        /// <summary>
        /// 获取一个值，该值表示命令。
        /// </summary>
        public ICommand Command { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示命令参数。
        /// </summary>
        public CommandParameter Parameter { get; private set; }

        /// <summary>
        /// 当命令参数的值发生改变时，通知命令目标更改其状态。
        /// </summary>
        public event EventHandler RequerySuggested;

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

        internal void ExecuteCommand()
        {
            Command.Execute(Parameter?.ParameterValue);
        }

        internal bool CanExecuteCommand()
        {
            return Command.CanExecute(Parameter?.ParameterValue);
        }
        private void OnRequerySuggested(object sender, EventArgs e)
        {
            RequerySuggested?.Invoke(this, e);
        }
    }
}
