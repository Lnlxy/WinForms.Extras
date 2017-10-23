using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Tests
{
    public partial class MainForm : Form, INotifyPropertyChanged
    {
        int r, g, b;
        public int R
        {
            get { return r; }
            set
            {
                r = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("R"));
            }
        }
        public int G
        {
            get { return g; }
            set
            {
                g = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("G"));
            }
        }
        public int B
        {
            get { return b; }
            set
            {
                b = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("B"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            textBox1.Binding(i => i.Text, this, i => i.Text)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged);
            lblTotal.MultiDataBinding(i => i.Text, () => new List<DataSourceMemeber> {
                DataSourceMemeber.Create(this, x => x.R),
                DataSourceMemeber.Create(this, x => x.G),
                DataSourceMemeber.Create(this, x => x.B),
            }, new MultiValueToStringConverter())
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            txtAppName.Binding(i => i.Text, lblTotal, i => i.Text).SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);

            nudR.Binding(i => i.Value, this, i => i.R)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            nudG.Binding(i => i.Value, this, i => i.G)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            nudB.Binding(i => i.Value, this, i => i.B)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);

            lblColor.MultiDataBinding(i => i.BackColor, () => new List<DataSourceMemeber> {
                DataSourceMemeber.Create(this, x => x.R),
                DataSourceMemeber.Create(this, x => x.G),
                DataSourceMemeber.Create(this, x => x.B),
            }, new RGBToColorConverter())
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged);
            lblColor.DataBinding(i => i.Text, lblColor, i => i.BackColor, new ColorToStringConverter())
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);

            lblR.DataBinding(i => i.Text, nudR, i => i.Value, new ObjectToStringConverter())
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            lblG.DataBinding(i => i.Text, nudG, i => i.Value, new ObjectToStringConverter())
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            lblB.DataBinding(i => i.Text, nudB, i => i.Value, new ObjectToStringConverter())
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            btnAddR.Command(this, i => i.R, i => R = i + 1, i => i >= 0 & i < 255);
            btnAddG.Command(this, i => i.G, i => G = i + 1, i => i >= 0 & i < 255);
            btnAddB.Command(this, i => i.B, i => B = i + 1, i => i >= 0 & i < 255);

        }

        private void OnACHanged(object sender, EventArgs e)
        {
        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                lblColor.BackColor = cd.Color;
            }
        }
    }

    internal class ColorToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            return color.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class MultiValueToStringConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return $"Red:{values[0]}|Green:{values[1]}|Blue:{values[2]}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal class ObjectToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ChangeType(value, targetType);
        }
    }

    internal class RGBToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.FromArgb(System.Convert.ToInt32(values[0]), System.Convert.ToInt32(values[1]), System.Convert.ToInt32(values[2]));
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var color = (Color)value;
            var values = new object[3];
            values.SetValue(color.R, 0);
            values.SetValue(color.G, 1);
            values.SetValue(color.G, 2);
            return values;
        }
    }
}
