// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="NotePadSettings.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System.ComponentModel;
using System.Drawing;

namespace Tests
{
    internal class NotePadSettings : INotifyPropertyChanged
    {
        #region Fields

        private Font font;

        private bool showSatausBar = false;

        private bool wordWrap = false;

        #endregion

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

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

        #endregion
    }
}
