// ***********************************************************************
// Author           : Hoze(hoze@live.cn)
// Created          : 06-20-2018
//
// ***********************************************************************
// <copyright file="Program.cs" company="Park Plus Inc.">
//     Copyright 2015 - 2018 (c) Park Plus Inc. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Tests
{
    internal static class Program
    {
        #region Methods

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var paths = Environment.GetCommandLineArgs();
            if (paths.Length == 1)
            {
                Application.Run(new NotePad());
            }
            else if (paths.Length == 2)
            {
                Application.Run(new NotePad(paths[1]));
            }
            else
            {
                foreach (var path in paths.Skip(1))
                {
                    AppDomain.CurrentDomain.ExecuteAssembly(Assembly.GetEntryAssembly().FullName, new string[] { path });
                }
            }
        }

        #endregion
    }
}
