namespace System.Windows.Forms
{
    /// <summary>
    /// 提供对 <see cref="Binding"/> 设置的方法。
    /// </summary>
    public static class BindingChain
    {
        /// <summary>
        /// 设置控件更新方式。
        /// </summary>
        /// <typeparam name="Binding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="mode">模式。</param>
        /// <returns>返回设置完成后的 <typeparamref name="Binding"/>。</returns>
        public static Binding SetControlUpdateMode(this Binding binding, ControlUpdateMode mode)
        {
            binding.ControlUpdateMode = mode;
            return binding;
        }

        /// <summary>
        /// 设置数据源默认值。
        /// </summary>
        /// <typeparam name="Binding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="value">值。</param>
        /// <returns>返回设置完成后的 <typeparamref name="Binding"/>。</returns>
        public static Binding SetDataSourceNullValue(this Binding binding, object value)
        {
            binding.DataSourceNullValue = value;
            return binding;
        }

        /// <summary>
        /// 设置数据源更新方式。
        /// </summary>
        /// <typeparam name="Binding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="mode">模式。</param>
        /// <returns>返回设置完成后的 <typeparamref name="Binding"/>。</returns>
        public static Binding SetDataSourceUpdateMode(this Binding binding, DataSourceUpdateMode mode)
        {
            binding.DataSourceUpdateMode = mode;
            return binding;
        }

        /// <summary>
        /// 设置格式化信息。
        /// </summary>
        /// <typeparam name="Binding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="formatInfo">格式化信息。</param>
        /// <returns>返回设置完成后的 <typeparamref name="Binding"/>。</returns>
        public static Binding SetFormatInfo(this Binding binding, IFormatProvider formatInfo)
        {
            binding.FormatInfo = formatInfo;
            return binding;
        }

        /// <summary>
        /// 设置数据格式字符串。
        /// </summary>
        /// <typeparam name="Binding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="formatString">格式。</param>
        /// <returns>返回设置完成后的 <typeparamref name="Binding"/>。</returns>
        public static Binding SetFormatString(this Binding binding, string formatString)
        {
            binding.FormatString = formatString;
            return binding;
        }

        /// <summary>
        /// 设置是否启用格式化。
        /// </summary>
        /// <typeparam name="Binding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="formattingEnabled">启用格式化。</param>
        /// <returns>返回设置完成后的 <typeparamref name="Binding"/>。</returns>
        public static Binding SetFormattingEnabled(this Binding binding, bool formattingEnabled)
        {
            binding.FormattingEnabled = formattingEnabled;
            return binding;
        }
    }
}
