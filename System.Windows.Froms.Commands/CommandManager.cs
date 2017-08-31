using System.Windows.Forms;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Diagnostics;

namespace System.Windows.Froms.Commands
{
    public static class CommandManager
    {

        class RequerySuggestedCommandManager
        {
            class RequerySuggestedCommandFilter : IMessageFilter
            {
                private RequerySuggestedCommandManager requerySuggestedCommandManager;
                public RequerySuggestedCommandFilter(RequerySuggestedCommandManager requerySuggestedCommandManager)
                {
                    this.requerySuggestedCommandManager = requerySuggestedCommandManager;
                }
                Stopwatch sw = Stopwatch.StartNew();
                long ticks = 0;
                public bool PreFilterMessage(ref Message m)
                {
                    if (m.Msg == 0xF)
                    {
                        return false;
                    }
                    if (m.Msg == 0x200)
                    {
                        return false;
                    }
                    if (m.Msg == 0xA0)
                    {
                        return false;
                    }
                    var time = sw.ElapsedMilliseconds - ticks;
                    Debug.WriteLine($"Msg:{m.Msg.ToString("X")} {time} ms");
                    requerySuggestedCommandManager.RaiseRequerySuggested();
                    ticks = sw.ElapsedMilliseconds;
                    return false;
                }
            }

            public event System.EventHandler RequerySuggested;

            public void Initialize()
            {
                Application.AddMessageFilter(new RequerySuggestedCommandFilter(this));
            }

            public void RaiseRequerySuggested()
            {
                RequerySuggested?.Invoke(this, EventArgs.Empty);
            }
        }

        private static readonly RequerySuggestedCommandManager requerySuggestedCommandManager = new RequerySuggestedCommandManager();
        private static readonly List<CommandBinding> applicationCommandBindings = new List<CommandBinding>();

        public static IEnumerable<CommandBinding> ApplicationCommandBindings { get => applicationCommandBindings; }

        /// <summary>
        /// 检测可能更改要执行的命令的功能的条件时发生
        /// </summary>
        public static event EventHandler RequerySuggested
        {
            add { requerySuggestedCommandManager.RequerySuggested += value; }
            remove { requerySuggestedCommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// 强制引发 <see cref="RequerySuggested"/> 事件。
        /// </summary>
        public static void InvalidateRequerySuggested()
        {
            SynchronizationContext.Current.Post(delegate
            {
                requerySuggestedCommandManager.RaiseRequerySuggested();
            }, null);
        }

        public static void Initialize()
        {
            requerySuggestedCommandManager.Initialize();
        }

        public static CommandBinding Add(Control control, ICommand command, CommandParameter commandParameter)
        {
            return Add(control, new CommandSource(command, commandParameter));
        }

        public static CommandBinding Add(Control control, CommandSource commandSource)
        {
            var input = new ControlTarget(control);
            return Add(input, commandSource);
        }

        public static CommandBinding Add(MenuItem component, ICommand command, CommandParameter commandParameter)
        {
            return Add(component, new CommandSource(command, commandParameter));
        }

        public static CommandBinding Add(MenuItem component, CommandSource commandSource)
        {
            var input = new MenuItemTarget(component);
            return Add(input, commandSource);
        }

        public static CommandBinding Add(ToolStripItem component, ICommand command, CommandParameter commandParameter)
        {
            return Add(component, new CommandSource(command, commandParameter));
        }
        public static CommandBinding Add(ToolStripItem component, CommandSource commandSource)
        {
            var input = new ToolStripItemTarget(component);
            return Add(input, commandSource);
        }
        public static CommandBinding Add(IInputTarget input, ICommand command, CommandParameter commandParameter)
        {
            return Add(input, new CommandSource(command, commandParameter));
        }
        public static CommandBinding Add(IInputTarget input, CommandSource commandSource)
        {
            var binding = new CommandBinding(input, commandSource);
            applicationCommandBindings.Add(binding);
            return binding;
        }
    }
}
