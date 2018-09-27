using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;

namespace YouTubeBrowserApp
{
    internal sealed class ApplicationController<TMainForm> : WindowsFormsApplicationBase
        where TMainForm : Form, new()
    {
        private readonly TMainForm _mainForm;

        public ApplicationController()
        {
            _mainForm = new TMainForm();

            IsSingleInstance = true;
            StartupNextInstance += ApplicationController_StartupNextInstance;
        }

        private void ApplicationController_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            e.BringToForeground = true;

            _mainForm.ShowInTaskbar = true;
            _mainForm.WindowState = FormWindowState.Minimized;
            _mainForm.Show();
            _mainForm.WindowState = FormWindowState.Normal;
        }

        protected override void OnCreateMainForm()
        {
            MainForm = _mainForm;
        }
    }
}
