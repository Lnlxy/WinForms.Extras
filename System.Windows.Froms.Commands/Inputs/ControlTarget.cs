using System.Windows.Forms;

namespace System.Windows.Froms.Commands
{
    class ControlTarget : IInputTarget
    {
        private readonly Control _control;
        public bool Enabled { get => _control.Enabled; set => _control.Enabled = value; }

        public event EventHandler Click
        {
            add { _control.Click += value; }
            remove { _control.Click -= value; }
        }

        public ControlTarget(Control control)
        {
            _control = control;
        }
    }
}
