using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tests
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
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
    }
}
