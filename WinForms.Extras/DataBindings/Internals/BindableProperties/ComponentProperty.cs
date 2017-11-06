using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 支持非 <see cref="IBindableComponent"/> 组件的绑定。
    /// </summary>
    public class ComponentProperty : IBindableProperty
    {
        private readonly Internals.SourcePropertyDescriptor bindingProperty;

        private bool isBinded;

        /// <summary>
        /// 初始化 <see cref="ComponentProperty"/> 新实例。
        /// </summary>
        /// <param name="component"></param>
        /// <param name="propertyName"></param>
        public ComponentProperty(Component component, string propertyName)
        {
            Component = component;
            PropertyName = propertyName;
            bindingProperty = Internals.SourceTypeDescriptor.GetProperty(component, propertyName);
        }

        /// <summary>
        /// 获取一个值，该值表示属性所属组件。
        /// </summary>
        public Component Component { get; private set; }

        /// <summary>
        /// 获取或设置一个值，该值表示控件属性更新方式。
        /// </summary>
        public ControlUpdateMode ControlUpdateMode { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值表示数据源更新方式。
        /// </summary>
        public DataSourceUpdateMode DataSourceUpdateMode { get; set; }

        /// <summary>
        /// 获取一个值，该值表示属性名称。
        /// </summary>
        public string PropertyName { get; private set; }

        /// <summary>
        /// 绑定指定的值到属性。
        /// </summary>
        /// <param name="value">绑定的值。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding(IValueObject value)
        {
            BindingCore(value, null, null);
            return this;
        }

        /// <summary>
        /// 绑定指定的值到属性，并使用指定的转换器。
        /// </summary>
        /// <param name="value">绑定的值。</param>
        /// <param name="converter">更新时，值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">区域信息。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding(IValueObject value, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            BindingCore(value, i => converter.Convert(i, bindingProperty.PropertyType, converter, culture), i => converter.ConvertBack(i, value.Type, convertParameter, culture));
            return this;
        }

        /// <summary>
        /// 绑定多个指定的值到属性，并使用指定的转换器。
        /// </summary>
        /// <param name="value">绑定的值。</param>
        /// <param name="converter">更新时，值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">区域信息。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding(MultiBindableValue value, IMultiValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            BindingCore(value, i => converter.Convert((object[])i, bindingProperty.PropertyType, converter, culture), i => converter.ConvertBack(i, value.ValueTypes, convertParameter, culture));
            return this;
        }

        /// <summary>
        /// 绑定数据源与成员到属性。
        /// </summary>
        /// <param name="dataSource">数据源。</param>
        /// <param name="member">数据源成员。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding(object dataSource, string member)
        {
            return Binding(new BindableValue(dataSource, member));
        }

        /// <summary>
        /// 绑定数据源与成员到属性，并使用指定的转换器。
        /// </summary>
        /// <param name="dataSource">数据源。</param>
        /// <param name="member">数据源成员。</param>
        /// <param name="converter">更新时，值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">区域信息。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding(object dataSource, string member, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            return Binding(new BindableValue(dataSource, member), converter, convertParameter, culture);
        }

        /// <summary>
        /// 绑定指定的值到属性。
        /// </summary>
        /// <param name="value">绑定的值。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding(ValueObject value)
        {
            BindingCore(value, null, null);
            return this;
        }

        /// <summary>
        /// 绑定数据源与成员到属性。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMember">数据源成员类型。</typeparam>
        /// <param name="dataSource">数据源。</param>
        /// <param name="member">数据源成员。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding<TSource, TMember>(TSource dataSource, Expression<Func<TSource, TMember>> expression)
        {
            return Binding(dataSource.CreateBindableValue(expression));
        }

        /// <summary>
        /// 绑定数据源与成员到属性，并使用指定的转换器。
        /// </summary>
        /// <typeparam name="TSource">数据源类型。</typeparam>
        /// <typeparam name="TMember">数据源成员类型。</typeparam>
        /// <param name="dataSource">数据源。</param>
        /// <param name="member">数据源成员。</param>
        /// <param name="converter">更新时，值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">区域信息。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding<TSource, TMember>(TSource dataSource, Expression<Func<TSource, TMember>> expression, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            return Binding(dataSource.CreateBindableValue(expression), converter, convertParameter, culture);
        }

        /// <summary>
        /// 绑定数据源与成员到属性。
        /// </summary>
        /// <param name="dataSourceType">静态数据源类型。</param>
        /// <param name="member">数据源成员。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding(Type dataSourceType, string member)
        {
            return Binding(new BindableValue(dataSourceType, member));
        }

        /// <summary>
        /// 绑定数据源与成员到属性，并使用指定的转换器。
        /// </summary>
        /// <param name="dataSourceType">静态数据源类型。</param>
        /// <param name="member">数据源成员。</param>
        /// <param name="converter">更新时，值转换器。</param>
        /// <param name="convertParameter">转换参数。</param>
        /// <param name="culture">区域信息。</param>ing"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        public IBindableProperty Binding(Type dataSourceType, string member, IValueConverter converter, object convertParameter = null, CultureInfo culture = null)
        {
            return Binding(new BindableValue(dataSourceType, member), converter, convertParameter, culture);
        }

        /// <summary>
        /// 确定该属性是否已绑定。
        /// </summary>
        /// <returns></returns>
        public bool IsBinded()
        {
            return isBinded;
        }

        private void BindingCore(IValueObject dataSourceValue, Func<object, object> convert, Func<object, object> convertBack)
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

        private void ReadValue(IValueObject dataSourceValue, Func<object, object> convert)
        {
            var originalValue = dataSourceValue.Value;
            var newValue = convert?.Invoke(originalValue) ?? originalValue;
            if (!object.Equals(newValue, bindingProperty.GetValue(Component)))
            {
                bindingProperty.SetValue(Component, newValue);
            }
        }

        private void WriteValue(IValueObject dataSourceValue, Func<object, object> convertBack)
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
