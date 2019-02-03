using System;
using System.Drawing;
using System.Windows.Forms;
using YouTubeBrowserApp.Properties;

namespace YouTubeBrowserApp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(SettingsForm_Load), sender, e);
                return;
            }

            Font = SystemFonts.MessageBoxFont;
        }

        public bool RememberWindowBound {
            get { return RememberWindowBoundCheckBox.Checked; }
            set { RememberWindowBoundCheckBox.Checked = value; }
        }

        public bool RememberLastPage {
            get { return RememberLastPageCheckBox.Checked; }
            set { RememberLastPageCheckBox.Checked = value; }
        }

        public bool AlwaysOnTop {
            get { return AlwaysOnTopCheckBox.Checked; }
            set { AlwaysOnTopCheckBox.Checked = value; }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(AboutButton_Click), sender, e);
                return;
            }

            MessageBox.Show(this, Resources.AboutDialogText, Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
