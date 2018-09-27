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
            UpdateWebBrowserVersion();

            Application.OleRequired();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController<MainForm>();
            controller.Run(Environment.GetCommandLineArgs());
        }

        private static void UpdateWebBrowserVersion()
        {
            var targetPath = @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
            var execFileName = Path.GetFileName(Process.GetCurrentProcess().MainModule.FileName);
            var subKey = Registry.CurrentUser.OpenSubKey(targetPath, true);

            if (subKey == null)
                subKey = Registry.CurrentUser.CreateSubKey(targetPath);

            using (subKey)
            {
                subKey.SetValue(execFileName, 11000);
            }
        }
    }
}
