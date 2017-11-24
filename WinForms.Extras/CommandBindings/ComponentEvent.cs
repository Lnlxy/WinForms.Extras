using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms.Internals;

namespace System.Windows.Forms
{
    public sealed class ComponentEvent
    {

        private readonly CommandTarget commandTarget;
        public ComponentEvent(Component component, string eventName)
        {
            commandTarget = new CommandTarget(component, eventName);
        }
        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public void Command(ICommand command)
        {
            new CommandBinding(command, commandTarget);
        }
        /// <summary>
        /// 添加命令。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <param name="commandParameter">命令执行参数。</param>
        /// <returns>返回 <see cref="CommandBinding"/> 新实例。</returns>
        public void Command(ICommand command, object commandParameter)
        {
            new CommandBinding(command, commandTarget, commandParameter);
        }
    }
}
