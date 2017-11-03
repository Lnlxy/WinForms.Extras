using System.ComponentModel;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义数据绑定项。
    /// </summary>
    public interface IBindableValue : INotifyPropertyChanged
    {
        /// <summary>
        /// 获取一个值，该值表示值类型。
        /// </summary>
        Type ValueType { get; }

        /// <summary>
        /// 获取后设置一个值，该值表示绑定的属性值。
        /// </summary>
        object Value { get; set; }
    }
}
