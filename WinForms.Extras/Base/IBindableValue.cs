using System.ComponentModel;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义数据绑定项。
    /// </summary>
    public interface IBindableValue : IObjectValue, INotifyPropertyChanged
    {
        /// <summary>
        /// 获取一个值，该值表示值类型。
        /// </summary>
        Type ValueType { get; }
    }
}
