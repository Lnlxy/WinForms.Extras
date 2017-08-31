using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Windows.Froms.Commands
{
      class KeysTarget : IInputTarget
    {
        private readonly Keys _keys;
        public bool Enabled { get; set; }

        public event EventHandler Click;

        public KeysTarget(Keys keys)
        {
            _keys = keys;
        }
    }
}
