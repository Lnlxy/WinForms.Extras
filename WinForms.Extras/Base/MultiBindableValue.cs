using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义多值绑定关系。
    /// </summary>
    public class MultiBindableValue : IBindableValue
    {
        private readonly List<IBindableValue> _items = new List<IBindableValue>();

        public MultiBindableValue(IBindableValue item1, IBindableValue item2, params IBindableValue[] items)
            : this(new List<IBindableValue> { item1, item2 }.Concat(items).ToList())
        {
        }

        public MultiBindableValue(IEnumerable<IBindableValue> items)
        {
            foreach (var item in items)
            {
                item.PropertyChanged += OnPropertyChanged;
            }
            _items.AddRange(items);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Type[] ItemTypes { get => _items.Select(i => i.ValueType).ToArray(); }

        public object Value { get => GetValue(); set => SetValue(value); }

        public Type ValueType => typeof(object[]);

        public object GetValue()
        {
            return _items.Select(i => i.Value).ToArray();
        }

        public void SetValue(object newValue)
        {
            var array = (object[])newValue;
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].Value = array[i];
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
        }
    }
}
