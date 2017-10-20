namespace System.Windows.Forms
{
    /// <summary>
    /// 命令绑定。
    /// </summary>
    public sealed class CommandBinding
    {
        /// <summary>
        /// 获取一个值，该值表示此绑定信息唯一标记。
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示命令源。
        /// </summary>
        public CommandSource Source { get; private set; }

        /// <summary>
        /// 获取一个值，该值表示命令目标。
        /// </summary>
        public ComponentTarget Target { get; private set; }

        internal CommandBinding(CommandSource source, ComponentTarget target)
        {
            Id = Guid.NewGuid();
            Source = source;
            Source.RequerySuggested += CommandSource_RequerySuggested;
            Target = target;
            target.DefaultEventHandled += Target_DefaultEventHandled;
            Target.Enabled = Source.CanExecuteCommand();
        }

        private void Target_DefaultEventHandled(object sender, EventArgs e)
        {
            Source.ExecuteCommand();
        }

        private void CommandSource_RequerySuggested(object sender, EventArgs e)
        {
            Target.Enabled = Source.CanExecuteCommand();
        }
    }
}
