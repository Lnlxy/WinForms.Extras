using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tests
{
    class NotePadSettings : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool wordWrap = false;
        private bool showSatausBar = false;

        private Font font;
        public Font Font
        {
            get => font;
            set
            {
                if (font != value)
                {
                    font = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Font"));
                }
            }
        }

        public bool ShowStatusBar
        {
            get => showSatausBar; set
            {
                if (showSatausBar != value)
                {
                    showSatausBar = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ShowStatusBar"));
                }
            }
        }


        /// <summary>
        /// 自动换行。
        /// </summary>
        public bool WordWrap
        {
            get => wordWrap;
            set
            {
                if (wordWrap != value)
                {
                    wordWrap = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WordWrap"));
                }
            }
        }
    }
}
