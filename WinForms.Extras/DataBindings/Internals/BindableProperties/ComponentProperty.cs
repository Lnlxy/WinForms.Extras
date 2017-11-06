using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    public class ComponentProperty : IBindableProperty
    {
        private readonly Internals.SourcePropertyDescriptor bindingProperty;

        private bool isBinded;

        public ComponentProperty(Component component, string propertyName)
        {
            Component = component;
            PropertyName = propertyName;
            bindingProperty = Internals.SourceTypeDescriptor.GetProperty(component, propertyName);
        }

        public Component Component { get; private set; }

        public ControlUpdateMode ControlUpdateMode { get; set; }

        public DataSourceUpdateMode DataSourceUpdateMode { get; set; }

        public string PropertyName { get; private set; }

        public IBindableProperty Binding(IObjectValue value)
        {
            BindingCore(value, null, null);
            return this;
        }

        public IBindableProperty Binding(IObjectValue value, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            BindingCore(value, i => converter.Convert(i, bindingProperty.PropertyType, converter, culture), i => converter.ConvertBack(i, value.Type, convertParameter, culture));
            return this;
        }

        public IBindableProperty Binding(MultiBindableValue value, IMultiValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            BindingCore(value, i => converter.Convert((object[])i, bindingProperty.PropertyType, converter, culture), i => converter.ConvertBack(i, value.ItemTypes, convertParameter, culture));
            return this;
        }

        public IBindableProperty Binding(object dataSource, string member)
        {
            return Binding(new BindableValue(dataSource, member));
        }

        public IBindableProperty Binding(object dataSource, string member, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            return Binding(new BindableValue(dataSource, member), converter, convertParameter, culture);
        }

        public IBindableProperty Binding(ObjectValue value)
        {
            BindingCore(value, null, null);
            return this;
        }

        public IBindableProperty Binding<TSource, TMember>(TSource dataSource, Expression<Func<TSource, TMember>> expression)
        {
            return Binding(dataSource.CreateBindableValue(expression));
        }

        public IBindableProperty Binding<TSource, TMember>(TSource dataSource, Expression<Func<TSource, TMember>> expression, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            return Binding(dataSource.CreateBindableValue(expression), converter, convertParameter, culture);
        }

        public IBindableProperty Binding(Type dataSourceType, string member)
        {
            return Binding(new BindableValue(dataSourceType, member));
        }

        public IBindableProperty Binding(Type dataSourceType, string member, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            return Binding(new BindableValue(dataSourceType, member), converter, convertParameter, culture);
        }

        public bool IsBinded()
        {
            return isBinded;
        }

        private void BindingCore(IObjectValue dataSourceValue, Func<object, object> convert, Func<object, object> convertBack)
        {
            isBinded = true;
            ReadValue(dataSourceValue, convert);
            bindingProperty.AddValueChanged(Component, (s, e) =>
            {
                if (DataSourceUpdateMode != DataSourceUpdateMode.Never)
                {
                    WriteValue(dataSourceValue, convertBack);
                }
            });
            dataSourceValue.ValueChanged += (e, s) =>
            {
                if (ControlUpdateMode != ControlUpdateMode.Never)
                {
                    ReadValue(dataSourceValue, convert);
                }
            };
        }

        private void ReadValue(IObjectValue dataSourceValue, Func<object, object> convert)
        {
            var originalValue = dataSourceValue.Value;
            var newValue = convert?.Invoke(originalValue) ?? originalValue;
            if (!object.Equals(newValue, bindingProperty.GetValue(Component)))
            {
                bindingProperty.SetValue(Component, newValue);
            }
        }

        private void WriteValue(IObjectValue dataSourceValue, Func<object, object> convertBack)
        {
            var originalValue = bindingProperty.GetValue(Component);
            var newValue = convertBack?.Invoke(originalValue) ?? originalValue;
            if (!object.Equals(newValue, dataSourceValue.Value))
            {
                dataSourceValue.Value = newValue;
            }
        }
    }
}
