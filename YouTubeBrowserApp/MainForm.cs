using System;
using System.Linq;
using System.Windows.Forms;

namespace YouTubeBrowserApp
{
    public partial class MainForm : Form
    {
        public MainForm() : base()
        {
            InitializeComponent();

            WebView.DocumentTitleChanged += WebView_DocumentTitleChanged;
        }

        private void UpdateWindowVisibility(bool visible)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(UpdateWindowVisibility), visible);
                return;
            }

            if (visible)
            {
                ShowInTaskbar = true;
                WindowState = FormWindowState.Minimized;
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
            }
            else
            {
                ShowInTaskbar = false;
                Hide();
            }
        }

        private void WebView_DocumentTitleChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(WebView_DocumentTitleChanged), sender, e);
                return;
            }

            Text = WebView.DocumentTitle;
            NotifyIcon.Text = WebView.DocumentTitle;
            NotifyIcon.BalloonTipTitle = WebView.DocumentTitle;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(MainForm_Load), sender, e);
                return;
            }

            var firstArgs = Environment.GetCommandLineArgs().ElementAtOrDefault(1);
            var uri = new Uri("https://www.youtube.com/", UriKind.Absolute);

            if (!string.IsNullOrWhiteSpace(firstArgs))
                uri = new Uri($"https://www.youtube.com/watch?v={Uri.EscapeDataString(firstArgs)}", UriKind.Absolute);

            WebView.Navigate(uri);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(MainForm_Resize), sender, e);
                return;
            }

            if (WindowState == FormWindowState.Minimized)
                UpdateWindowVisibility(false);
        }

        private void MainForm_VisibleChanged(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(MainForm_VisibleChanged), sender, e);
                return;
            }

            NotifyIcon.Visible = !Visible;
        }

        private void RestoreWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(RestoreWindowToolStripMenuItem_Click), sender, e);
                return;
            }

            UpdateWindowVisibility(true);
        }

        private void CloseAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(CloseAppToolStripMenuItem_Click), sender, e);
                return;
            }

            Close();
        }

        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MouseEventHandler(NotifyIcon_MouseClick), sender, e);
                return;
            }

            if (e.Button == MouseButtons.Left)
                UpdateWindowVisibility(true);
        }

        private void AboutAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(AboutAppToolStripMenuItem_Click), sender, e);
                return;
            }

            MessageBox.Show(this, @"YouTube Browser App, v1.0
(c) 2018 rkttu.com, All rights reserved.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }
    }
}
