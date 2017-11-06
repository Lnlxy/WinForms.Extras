using System.Globalization;
using System.Linq.Expressions;

namespace System.Windows.Forms
{
    /// <summary>
    /// 定义绑定方法。
    /// </summary>
    public interface IBindableProperty
    {
        /// <summary>
        /// 获取或设置一个值，该值表示控件属性更新方式。
        /// </summary>
        ControlUpdateMode ControlUpdateMode { get; set; }

        /// <summary>
        /// 获取或设置一个值，该值表示数据源更新方式。
        /// </summary>
        DataSourceUpdateMode DataSourceUpdateMode { get; set; }

        /// <summary>
        /// 获取一个值，该值表示属性名称。
        /// </summary>
        string PropertyName { get; }

        /// <summary>
        /// 绑定指定的值到属性。
        /// </summary>
        /// <param name="value">绑定的值。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        IBindableProperty Binding(IValueObject value);

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
        IBindableProperty Binding(IValueObject value, IValueConverter converter, object convertParameter = null, CultureInfo culture = null);

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
        IBindableProperty Binding(MultiBindableValue value, IMultiValueConverter converter, object convertParameter = null, CultureInfo culture = null);

        /// <summary>
        /// 绑定数据源与成员到属性。
        /// </summary>
        /// <param name="dataSource">数据源。</param>
        /// <param name="member">数据源成员。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        IBindableProperty Binding(object dataSource, string member);

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
        IBindableProperty Binding(object dataSource, string member, IValueConverter converter, object convertParameter = null, CultureInfo culture = null);

        /// <summary>
        /// 绑定指定的值到属性。
        /// </summary>
        /// <param name="value">绑定的值。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        IBindableProperty Binding(ValueObject value);

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
        IBindableProperty Binding<TSource, TMember>(TSource dataSource, Expression<Func<TSource, TMember>> expression);

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
        IBindableProperty Binding<TSource, TMember>(TSource dataSource, Expression<Func<TSource, TMember>> expression, IValueConverter converter, object convertParameter = null, CultureInfo culture = null);

        /// <summary>
        /// 绑定数据源与成员到属性。
        /// </summary>
        /// <param name="dataSourceType">静态数据源类型。</param>
        /// <param name="member">数据源成员。</param>
        /// <returns>返回已绑定的 <see cref="Forms.Binding"/> 实例。</returns>
        /// <exception cref="ArgumentException">给定数据为null时引发。</exception>
        /// <exception cref="ArgumentNullException">控件属性是已绑定到数据或<see cref="Forms.Binding"/> 未指定的有效列时引发。</exception>
        IBindableProperty Binding(Type dataSourceType, string member);

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
        IBindableProperty Binding(Type dataSourceType, string member, IValueConverter converter, object convertParameter = null, CultureInfo culture = null);

        /// <summary>
        /// 确定该属性是否已绑定。
        /// </summary>
        /// <returns>返回一个值，确定属性是否已绑定。</returns>
        bool IsBinded();
    }
}
