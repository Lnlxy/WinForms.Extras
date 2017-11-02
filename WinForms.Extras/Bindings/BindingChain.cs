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
        /// <typeparam name="TBinding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="mode">模式。</param>
        /// <returns>返回设置完成后的 <typeparamref name="TBinding"/>。</returns>
        public static TBinding SetControlUpdateMode<TBinding>(this TBinding binding, ControlUpdateMode mode) where TBinding : Binding
        {
            binding.ControlUpdateMode = mode;
            return binding;
        }

        /// <summary>
        /// 设置数据源默认值。
        /// </summary>
        /// <typeparam name="TBinding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="value">值。</param>
        /// <returns>返回设置完成后的 <typeparamref name="TBinding"/>。</returns>
        public static TBinding SetDataSourceNullValue<TBinding>(this TBinding binding, object value) where TBinding : Binding
        {
            binding.DataSourceNullValue = value;
            return binding;
        }

        /// <summary>
        /// 设置数据源更新方式。
        /// </summary>
        /// <typeparam name="TBinding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="mode">模式。</param>
        /// <returns>返回设置完成后的 <typeparamref name="TBinding"/>。</returns>
        public static TBinding SetDataSourceUpdateMode<TBinding>(this TBinding binding, DataSourceUpdateMode mode) where TBinding : Binding
        {
            binding.DataSourceUpdateMode = mode;
            return binding;
        }

        /// <summary>
        /// 设置格式化信息。
        /// </summary>
        /// <typeparam name="TBinding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="formatInfo">格式化信息。</param>
        /// <returns>返回设置完成后的 <typeparamref name="TBinding"/>。</returns>
        public static TBinding SetFormatInfo<TBinding>(this TBinding binding, IFormatProvider formatInfo) where TBinding : Binding
        {
            binding.FormatInfo = formatInfo;
            return binding;
        }

        /// <summary>
        /// 设置数据格式字符串。
        /// </summary>
        /// <typeparam name="TBinding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="formatString">格式。</param>
        /// <returns>返回设置完成后的 <typeparamref name="TBinding"/>。</returns>
        public static TBinding SetFormatString<TBinding>(this TBinding binding, string formatString) where TBinding : Binding
        {
            binding.FormatString = formatString;
            return binding;
        }

        /// <summary>
        /// 设置是否启用格式化。
        /// </summary>
        /// <typeparam name="TBinding">绑定类型。</typeparam>
        /// <param name="binding">源。</param>
        /// <param name="formattingEnabled">启用格式化。</param>
        /// <returns>返回设置完成后的 <typeparamref name="TBinding"/>。</returns>
        public static TBinding SetFormattingEnabled<TBinding>(this TBinding binding, bool formattingEnabled) where TBinding : Binding
        {
            binding.FormattingEnabled = formattingEnabled;
            return binding;
        }
    }
}
