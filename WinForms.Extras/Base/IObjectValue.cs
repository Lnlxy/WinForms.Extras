using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Windows.Forms
{
    public interface IObjectValue
    {

        /// <summary>
        /// 获取后设置一个值，该值表示此实例的值。
        /// </summary>
        object Value { get; set; }
    }
}
