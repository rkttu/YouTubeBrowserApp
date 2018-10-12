using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        public bool RememberWindowBound {
            get => RememberWindowBoundCheckBox.Checked;
            set => RememberWindowBoundCheckBox.Checked = value;
        }

        public bool RememberLastPage {
            get => RememberLastPageCheckBox.Checked;
            set => RememberLastPageCheckBox.Checked = value;
        }

        public bool AlwaysOnTop {
            get => AlwaysOnTopCheckBox.Checked;
            set => AlwaysOnTopCheckBox.Checked = value;
        }
    }
}
