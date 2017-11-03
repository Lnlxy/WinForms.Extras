namespace System.Windows.Forms
{
    /// <summary>
    /// 定义数据绑定项。
    /// </summary>
    public interface IDataBoundItem
    {
        /// <summary>
        /// 获取一个值，该值表示值类型。
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// 获取绑定值。
        /// </summary>
        /// <returns></returns>
        object GetValue();

        /// <summary>
        /// 设置绑定值。
        /// </summary>
        /// <param name="newValue"></param>
        void SetValue(object newValue);

        /// <summary>
        /// 值改变时的回调。
        /// </summary>
        /// <param name="callback"></param>
        void ValueChangedCallback(EventHandler callback);
    }
}
