using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace YouTubeBrowserApp
{
    internal static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.OleRequired();

            NativeMethods.SetProcessDpiAwareness(NativeMethods.PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE);

            SetWebViewFeature("FEATURE_BROWSER_EMULATION", 11000);
            SetWebViewFeature("FEATURE_96DPI_PIXEL", 1);

            using (var mainForm = new MainForm())
            {
                var appContext = new ApplicationContext(mainForm);
                Application.Run(appContext);
            }
        }

        private static void SetWebViewFeature(string featureName, object value)
        {
            var targetPath = $@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\{featureName}";
            var execFileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
            var subKey = Registry.CurrentUser.OpenSubKey(targetPath, true);

            if (subKey == null)
                subKey = Registry.CurrentUser.CreateSubKey(targetPath);

            using (subKey)
            {
                subKey.SetValue(execFileName, value);
            }
        }
    }
}
