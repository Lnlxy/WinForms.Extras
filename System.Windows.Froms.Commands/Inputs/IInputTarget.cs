using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Froms.Commands
{
    public interface IInputTarget
    {
        event EventHandler Click;

        bool Enabled { get; set; }
    }
}
