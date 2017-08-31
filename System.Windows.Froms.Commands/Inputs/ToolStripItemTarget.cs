using System.Windows.Forms;

namespace System.Windows.Froms.Commands
{
    class ToolStripItemTarget : IInputTarget
    {
        private readonly ToolStripItem _toolStripItem;
        public bool Enabled { get => _toolStripItem.Enabled; set => _toolStripItem.Enabled = value; }

        public event EventHandler Click
        {
            add { _toolStripItem.Click += value; }
            remove { _toolStripItem.Click -= value; }
        }

        public ToolStripItemTarget(ToolStripItem toolStripItem)
        {
            _toolStripItem = toolStripItem;
        }
    }
}
