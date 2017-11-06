using System.Globalization;

namespace System.Windows.Forms
{
    public sealed class BooleanToCheckedStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool?)
            {
                var decision = (bool?)value;
                if (!decision.HasValue)
                {
                    return CheckState.Indeterminate;
                }
                else if (decision.Value)
                {
                    return CheckState.Checked;
                }
                {
                    return CheckState.Unchecked;
                }
            }
            else if (!(value is bool))
            {
                throw new Exception();
            }
            else
            {
                var decision = (bool)value;
                if (decision)
                {
                    return CheckState.Checked;
                }
                {
                    return CheckState.Unchecked;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var state = (CheckState)value;
            if (state == CheckState.Indeterminate)
            {
                if (typeof(bool?).IsAssignableFrom(targetType))
                {
                    return null;
                }
                else
                {
                    return false;
                }
            }
            else if (state == CheckState.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
