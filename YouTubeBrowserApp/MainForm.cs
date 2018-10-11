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

        private void ToggleWindowMaximizeStatus()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ToggleWindowMaximizeStatus));
                return;
            }

            if (WindowState == FormWindowState.Maximized)
            {
                MaximizeButton.Text = "Maximize";
                WindowState = FormWindowState.Normal;
                Show();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                MaximizeButton.Text = "Restore";
                WindowState = FormWindowState.Maximized;
                Show();
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
            TitleLabel.Text = WebView.DocumentTitle;
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

            MessageBox.Show(this, @"YouTube Browser App, v1.0.1
(c) 2018 rkttu.com, All rights reserved.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(BackButton_Click), sender, e);
                return;
            }

            if (!WebView.CanGoBack)
                return;

            WebView.GoBack();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(NextButton_Click), sender, e);
                return;
            }

            if (!WebView.CanGoForward)
                return;

            WebView.GoForward();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(RefreshButton_Click), sender, e);
                return;
            }

            var option = WebBrowserRefreshOption.Normal;

            if (Control.ModifierKeys == Keys.Control ||
                Control.ModifierKeys == Keys.ControlKey ||
                Control.ModifierKeys == Keys.LControlKey ||
                Control.ModifierKeys == Keys.RControlKey)
                option = WebBrowserRefreshOption.Completely;

            WebView.Refresh(option);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new KeyEventHandler(MainForm_KeyUp), sender, e);
                return;
            }

            if (e.KeyCode == Keys.Back ||
                e.KeyCode == Keys.BrowserBack ||
                (e.Alt && e.KeyCode == Keys.Left))
            {
                BackButton.PerformClick();
                return;
            }

            if (e.KeyCode == Keys.BrowserForward ||
                (e.Alt && e.KeyCode == Keys.Right))
            {
                NextButton.PerformClick();
                return;
            }

            if (e.KeyCode == Keys.F5 ||
                e.KeyCode == Keys.BrowserRefresh)
            {
                RefreshButton.PerformClick();
                return;
            }
        }

        private void TitleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new MouseEventHandler(TitleLabel_MouseDown), sender, e);
                return;
            }

            if (e.Button == MouseButtons.Left)
            {
                if ((e.Clicks == 1) && (WindowState != FormWindowState.Maximized))
                {
                    NativeMethods.ReleaseCapture();
                    NativeMethods.SendMessageW(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
                }

                if (e.Clicks >= 2)
                {
                    ToggleWindowMaximizeStatus();
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(CloseButton_Click), sender, e);
                return;
            }

            Close();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(MinimizeButton_Click), sender, e);
                return;
            }

            UpdateWindowVisibility(false);
        }

        private void MaximizeButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(MaximizeButton_Click), sender, e);
                return;
            }

            ToggleWindowMaximizeStatus();
        }
    }
}
