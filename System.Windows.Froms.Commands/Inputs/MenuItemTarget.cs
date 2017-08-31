using System.Windows.Forms;

namespace System.Windows.Froms.Commands
{
    class MenuItemTarget : IInputTarget
    {
        private readonly MenuItem _menuItem;
        public bool Enabled { get => _menuItem.Enabled; set => _menuItem.Enabled = value; }

        public event EventHandler Click
        {
            add { _menuItem.Click += value; }
            remove { _menuItem.Click -= value; }
        }

        public MenuItemTarget(MenuItem menuItem)
        {
            _menuItem = menuItem;
        }
    }
}
