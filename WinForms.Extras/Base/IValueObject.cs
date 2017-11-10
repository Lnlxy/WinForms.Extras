namespace System.Windows.Forms
{
    /// <summary>
    /// 定义一个值对象，提供值改变时的事件通知。
    /// </summary>
    public interface IValueObject
    {
        /// <summary>
        /// 当值改变时，发生。
        /// </summary>
        event EventHandler ValueChanged;

        Type Type { get; }

        /// <summary>
        /// 获取后设置一个值，该值表示此实例的值。
        /// </summary>
        object Value { get; set; }
    }
}
