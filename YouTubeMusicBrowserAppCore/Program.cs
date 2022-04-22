using System;
using System.Windows.Forms;

namespace YouTubeMusicBrowserApp
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.OleRequired();

            NativeMethods.SetProcessDpiAwareness(NativeMethods.PROCESS_DPI_AWARENESS.PROCESS_PER_MONITOR_DPI_AWARE);

            using (var mainForm = new MainForm())
            {
                var appContext = new ApplicationContext(mainForm);
                Application.Run(appContext);
            }
        }
    }
}
