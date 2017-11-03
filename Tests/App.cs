using System;

namespace Tests
{
    public static class App
    {
        private static string appName;
        public static event EventHandler AppNameChanged;
        public static string AppName { get; set; }

        static App()
        {
            AppName = "Hello The Word.";
        }
    }
}
