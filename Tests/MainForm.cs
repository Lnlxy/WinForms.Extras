namespace Tests
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    public partial class MainForm : Form, INotifyPropertyChanged
    {
        int r, g, b;

        public MainForm()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public int B
        {
            get { return b; }
            set
            {
                b = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("B"));
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

        public int R
        {
            get { return r; }
            set
            {
                r = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("R"));
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            item1ToolStripMenuItem.Property(i => i.Text).Binding(txtMenuText, i => i.Text)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged);
            this.Property(i => i.R).Binding(254);
            var multiValues = this.CreateMultiBindableValue(i => i.R, i => i.G, i => i.B);
            lblTotal.Property()
                .Binding(multiValues, new MultiValueToStringConverter())
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            nudR.Property(i => i.Value).Binding(this, i => i.R)
                    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            nudG.Property(i => i.Value).Binding(this, i => i.G)
                    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            nudB.Property(i => i.Value).Binding(this, i => i.B)
                    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);

            lblColor.Property(i => i.BackColor).Binding(multiValues, new RGBToColorConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged);
            lblColor.Property(i => i.Text).Binding(lblColor, i => i.BackColor, new ColorToStringConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            lblR.Property(i => i.Text).Binding(nudR, i => i.Value, new ObjectToStringConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            lblG.Property(i => i.Text).Binding(nudG, i => i.Value, new ObjectToStringConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            lblB.Property(i => i.Text).Binding(nudB, i => i.Value, new ObjectToStringConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            btnAddR.Command(new RelayCommand<int>(i => R = i + 1, i => i >= 0 & i < 255), this, i => i.R);
            btnAddG.Command(new RelayCommand<int>(i => G = i + 1, i => i >= 0 & i < 255), this, i => i.G);
            btnAddB.Command(new RelayCommand<int>(i => B = i + 1, i => i >= 0 & i < 255), this, i => i.B);

            btnAll.Command(new RelayCommand(i =>
            {
                if (R < 255)
                {
                    R++;
                }
                if (G < 255)
                {
                    G++;
                }
                if (B < 255)
                {
                    B++;
                }
            }, i =>
            {
                var values = (object[])i;
                return (int)values[0] < 255 || (int)values[1] < 255 || (int)values[2] < 255;
            }), multiValues);
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

        private void OnACHanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            App.AppName = txtMenuText.Text;
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
