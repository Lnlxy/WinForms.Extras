namespace System.Windows.Forms
{
    /// <summary>
    /// 定义一个命令体，提供执行方法。
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 确定表示该命令是否能被执行。
        /// </summary>
        /// <param name="parameter">参数。</param>
        /// <returns>返回一个值，该值表示命令是否执行。</returns>
        bool CanExecute(object parameter);

        /// <summary>
        /// 执行命令。
        /// </summary>
        /// <param name="parameter">参数。</param>
        void Execute(object parameter);
    }
     
}
