using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
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
        public int G { get; set; }
        public int B { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public MainForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblTotal.CreateMultiDataBindingBuilder(i => i.Text)
                .SetConverter(new MultiValueToStringConverter(), null)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .SetDataSourceMemeber(this, x => x.R)
                .SetDataSourceMemeber(this, x => x.G)
                .SetDataSourceMemeber(this, x => x.B)
                .Build();

            nudR.CreateDataBindingBuilder(i => i.Value)
                .SetDataSourceMemeber(this, i => i.R)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .Build();
            nudG.CreateDataBindingBuilder(i => i.Value)
                .SetDataSourceMemeber(this, i => i.G)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .Build();
            nudB.CreateDataBindingBuilder(i => i.Value)
                .SetDataSourceMemeber(this, i => i.B)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .Build();

            lblColor.CreateMultiDataBindingBuilder(i => i.BackColor)
                .SetDataSourceMemeber(this, x => x.R)
                .SetDataSourceMemeber(this, x => x.G)
                .SetDataSourceMemeber(this, x => x.B)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                .SetConverter(new RGBToColorConverter(), null)
                .Build();
            lblColor.CreateDataBindingBuilder(i => i.Text)
                .SetDataSourceMemeber(lblColor, x => x.BackColor)
                .SetConverter(new ColorToStringConverter(), null)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .Build();

            lblR.CreateDataBindingBuilder(i => i.Text)
                .SetDataSourceMemeber(nudR, x => x.Value)
                .SetConverter(new ObjectToStringConverter(), null)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .Build();

            lblG.CreateDataBindingBuilder(i => i.Text)
                .SetDataSourceMemeber(nudG, x => x.Value)
                .SetConverter(new ObjectToStringConverter(), null)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .Build();

            lblB.CreateDataBindingBuilder(i => i.Text)
                .SetDataSourceMemeber(nudB, x => x.Value)
                .SetConverter(new ObjectToStringConverter(), null)
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                .Build();
            btnAddR.AddCommand(new RelayCommand<int>(x =>
            {
                R = x + 1;
            }, x =>
            {
                return x >= 0 && x < 255;
            }), this, x => x.R);

       
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
