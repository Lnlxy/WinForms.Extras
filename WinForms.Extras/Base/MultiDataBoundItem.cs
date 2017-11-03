using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义多值绑定关系。
    /// </summary>
    public class MultiDataBoundItem : IDataBoundItem, INotifyPropertyChanged
    {
        private readonly List<IDataBoundItem> _items = new List<IDataBoundItem>();

        private EventHandler handler = null;

        public MultiDataBoundItem()
        {
        }

        public MultiDataBoundItem(IDataBoundItem item1, IDataBoundItem item2, params IDataBoundItem[] items)
            : this(new List<IDataBoundItem> { item1, item2 }.Concat(items).ToList())
        {
        }

        public MultiDataBoundItem(List<IDataBoundItem> items)
        {
            foreach (var item in items)
            {
                item.ValueChangedCallback(OnValueChanged);
            }
            _items.AddRange(items);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Type[] ItemTypes { get => _items.Select(i => i.ValueType).ToArray(); }

        public object[] Values { get => (object[])GetValue(); set => SetValue(value); }

        public Type ValueType => typeof(object[]);

        public object GetValue()
        {
            return _items.Select(i => i.GetValue()).ToArray();
        }

        public void SetValue(object newValue)
        {
            var array = (object[])newValue;
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].SetValue(array[i]);
            }
        }

        public void ValueChangedCallback(EventHandler callback)
        {
            Delegate.Combine(handler, callback);
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            //只改变了，停止改变。
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Values"));
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
