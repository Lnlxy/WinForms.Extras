using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义可绑定组件的绑定属性信息。
    /// </summary>
    public class BindableComponentProperty : IBindableProperty
    {
        /// <summary>
        /// 初始化 <see cref="BindableComponentProperty"/> 新实例。
        /// </summary>
        /// <param name="component">组件。</param>
        /// <param name="propertyName">属性。</param>
        public BindableComponentProperty(IBindableComponent component, string propertyName)
        {
            Component = component;
            PropertyName = propertyName;
        }

        /// <summary>
        /// 获取一个值，该值表示组件信息。
        /// </summary>
        public IBindableComponent Component { get; private set; }

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
            var binding = Component.DataBindings.Add(PropertyName, value, "Value");
            binding.ControlUpdateMode = ControlUpdateMode;
            binding.DataSourceUpdateMode = DataSourceUpdateMode;
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
            return Binding(value, "Value", converter, convertParameter, culture);
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
            var binding = new MultiDataBinding(PropertyName, value, converter, convertParameter, culture);
            binding.ControlUpdateMode = ControlUpdateMode;
            binding.DataSourceUpdateMode = DataSourceUpdateMode;
            Component.DataBindings.Add(binding);
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
            var binding = Component.DataBindings.Add(PropertyName, dataSource, member);
            binding.ControlUpdateMode = ControlUpdateMode;
            binding.DataSourceUpdateMode = DataSourceUpdateMode;
            return this;
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
            var binding = new DataBinding(PropertyName, dataSource, member, converter, convertParameter, culture);
            binding.ControlUpdateMode = ControlUpdateMode;
            binding.DataSourceUpdateMode = DataSourceUpdateMode;
            Component.DataBindings.Add(binding);
            return this;
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
            return Binding((IValueObject)value);
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
            var member = (expression.Body as MemberExpression).Member.Name;
            return Binding(dataSource, member);
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
            var member = (expression.Body as MemberExpression).Member.Name;
            return Binding(dataSource, member, converter, convertParameter, culture);
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
            var bindableValue = new BindableValue(dataSourceType, member);
            return Binding(bindableValue);
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
            var bindableValue = new BindableValue(dataSourceType, member);
            return Binding(bindableValue, converter, convertParameter, culture);
        }

        /// <summary>
        /// 确定该属性是否已绑定。
        /// </summary>
        /// <returns></returns>
        public bool IsBinded()
        {
            return Component.DataBindings.OfType<Binding>().Any(i => i.PropertyName.Equals(PropertyName));
        }
    }
}
