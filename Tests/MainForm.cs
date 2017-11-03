﻿namespace Tests
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
            //textBox1.Binding(i => i.Text, this, i => i.Text)
            //    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
            //    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged);
            var mdbi = new MultiDataBoundItem(this.CreateDataBoundItem(x => x.R),
                this.CreateDataBoundItem(x => x.G),
                this.CreateDataBoundItem(x => x.B));
            lblTotal.Binding(i => i.Text, mdbi, new MultiValueToStringConverter())
                .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            //txtAppName.Binding(i => i.Text, lblTotal, i => i.Text).SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);

            nudR.Binding(i => i.Value, this, i => i.R)
                    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            nudG.Binding(i => i.Value, this, i => i.G)
                    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            nudB.Binding(i => i.Value, this, i => i.B)
                    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged)
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);

            lblColor.Binding(i => i.BackColor, mdbi, new RGBToColorConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged)
                    .SetDataSourceUpdateMode(DataSourceUpdateMode.OnPropertyChanged);
            lblColor.Binding(i => i.Text, lblColor, i => i.BackColor, new ColorToStringConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);

            lblR.Binding(i => i.Text, nudR, i => i.Value, new ObjectToStringConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            lblG.Binding(i => i.Text, nudG, i => i.Value, new ObjectToStringConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            lblB.Binding(i => i.Text, nudB, i => i.Value, new ObjectToStringConverter())
                    .SetControlUpdateMode(ControlUpdateMode.OnPropertyChanged);
            btnAddR.Command(this, i => i.R, i => R = i + 1, i => i >= 0 & i < 255);
            btnAddG.Command(this, i => i.G, i => G = i + 1, i => i >= 0 & i < 255);
            btnAddB.Command(this, i => i.B, i => B = i + 1, i => i >= 0 & i < 255);
            this.Binding(i => i.Text, typeof(App), "AppName");
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
            App.AppName = textBox1.Text;
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
