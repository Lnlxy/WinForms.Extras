namespace System.Windows.Froms.Commands
{
    /// <summary>
    /// 定义一个命令体，提供执行方法。
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 当出现影响是否应执行该命令的更改时发生。
        /// </summary>
        event EventHandler CanExecuteChanged;

        /// <summary>
        /// 确定一个值，表示该命令是否能被执行。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        bool CanExecute(object parameter);

        void Execute(object parameter);
    }
}
