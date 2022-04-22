using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using YouTubeMusicBrowserApp.Properties;

namespace YouTubeMusicBrowserApp
{
    public partial class MainForm : Form
    {
        public MainForm() : base()
        {
            InitializeComponent();

            // Adjust Tool Strip Size in High DPI mode - https://www.medo64.com/2014/01/scaling-toolstrip-with-dpi/
            Font = SystemFonts.MessageBoxFont;
            using (var graphics = CreateGraphics())
            {
                var scale = Math.Max(graphics.DpiX, graphics.DpiY) / 96d;
                var newScale = (int)Math.Floor(scale * 100) / 50 * 50 / 100d;

                if (newScale > 1)
                {
                    var newWidth = (int)(ToolStrip.ImageScalingSize.Width * newScale);
                    var newHeight = (int)(ToolStrip.ImageScalingSize.Height * newScale);
                    ToolStrip.ImageScalingSize = new Size(newWidth, newHeight);
                    ToolStrip.AutoSize = false;
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= NativeMethods.WS_SIZEBOX | NativeMethods.WS_MINIMIZEBOX;
                return cp;
            }
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
                WindowState = FormWindowState.Minimized;
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
                ShowInTaskbar = true;
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
                WindowState = FormWindowState.Normal;
                Show();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                Show();
            }
        }

        private void SetAlwaysOnTop(bool topmost)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(SetAlwaysOnTop), topmost);
                return;
            }

            TopMost = topmost;
            Settings.Default.AlwaysOnTop = TopMost;
            AlwaysOntopToolStripMenuItem.Checked = TopMost;
            Settings.Default.Save();
        }

        private void WebView_DocumentTitleChanged(object sender, object e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(WebView_DocumentTitleChanged), sender, e);
                return;
            }

            var title = WebView.CoreWebView2.DocumentTitle;

            if (String.IsNullOrWhiteSpace(title))
                title = Resources.AppTitle;

            Text = title;
            TitleLabel.Text = title;
            NotifyIcon.Text = title.Substring(0, Math.Min(title.Length, 63));
            NotifyIcon.BalloonTipTitle = title;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(MainForm_Load), sender, e);
                return;
            }

            WebView.EnsureCoreWebView2Async().ContinueWith((context) =>
            {
                if (context.Exception != null)
                {
                    Invoke(new Func<string, DialogResult>(MessageBox.Show), context.Exception.Message);
                    return;
                }

                Invoke(new Action<object, EventArgs>((_sender, _e) =>
                {
                    WebView.CoreWebView2.Settings.AreDevToolsEnabled = false;
                    WebView.CoreWebView2.Settings.AreDefaultScriptDialogsEnabled = false;
                    WebView.CoreWebView2.Settings.AreHostObjectsAllowed = false;
                    WebView.CoreWebView2.DocumentTitleChanged += WebView_DocumentTitleChanged;

                    SetAlwaysOnTop(Settings.Default.AlwaysOnTop);

                    if (Settings.Default.EnableRememberWindowBound)
                    {
                        if (!Settings.Default.LastWindowSize.IsEmpty)
                            Size = Settings.Default.LastWindowSize;

                        if (!Settings.Default.LastWindowPosition.IsEmpty)
                            Location = Settings.Default.LastWindowPosition;

                        FormWindowState state;
                        if (Enum.TryParse(Settings.Default.LastWindowState, out state))
                            WindowState = state;
                    }

                    var firstArgs = Environment.GetCommandLineArgs().ElementAtOrDefault(1);
                    var uri = new Uri("https://music.youtube.com/", UriKind.Absolute);
                    var lastUri = default(Uri);

                    if (!string.IsNullOrWhiteSpace(firstArgs))
                        uri = new Uri($"https://music.youtube.com/playlist?list={Uri.EscapeDataString(firstArgs)}", UriKind.Absolute);
                    else if (Settings.Default.EnableRememberLastUrl &&
                        Uri.TryCreate(Settings.Default.LastUrl, UriKind.Absolute, out lastUri) &&
                        (lastUri.Scheme == Uri.UriSchemeHttp || lastUri.Scheme == Uri.UriSchemeHttps) &&
                        lastUri.Host.EndsWith("music.youtube.com", StringComparison.OrdinalIgnoreCase))
                        uri = lastUri;

                    WebView.CoreWebView2.Navigate(uri.AbsoluteUri);

                }), sender, e);
            });
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

            MessageBox.Show(this, Resources.AboutDialogText, Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
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

            WebView.Refresh();
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
                if (e.Clicks == 1)
                {
                    if (WindowState != FormWindowState.Maximized)
                    {
                        NativeMethods.ReleaseCapture();
                        NativeMethods.SendMessage(Handle, NativeMethods.WM_NCLBUTTONDOWN, NativeMethods.HT_CAPTION, 0);
                    }
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

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new FormClosedEventHandler(MainForm_FormClosed), sender, e);
                return;
            }

            if (Settings.Default.EnableRememberWindowBound)
            {
                Settings.Default.LastWindowSize = Size;
                Settings.Default.LastWindowPosition = Location;
                Settings.Default.LastWindowState = WindowState.ToString();
            }

            if (Settings.Default.EnableRememberLastUrl)
                Settings.Default.LastUrl = WebView.Source.AbsoluteUri;

            Settings.Default.Save();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(SettingsButton_Click), sender, e);
                return;
            }

            using (var form = new SettingsForm()
            {
                RememberWindowBound = Settings.Default.EnableRememberWindowBound,
                RememberLastPage = Settings.Default.EnableRememberLastUrl,
                AlwaysOnTop = Settings.Default.AlwaysOnTop,
            })
            {
                if (form.ShowDialog(this) != DialogResult.OK)
                    return;

                Settings.Default.EnableRememberWindowBound = form.RememberWindowBound;
                Settings.Default.EnableRememberLastUrl = form.RememberLastPage;
                Settings.Default.Save();

                SetAlwaysOnTop(form.AlwaysOnTop);
            }
        }

        private void AlwaysOntopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(AlwaysOntopToolStripMenuItem_Click), sender, e);
                return;
            }

            SetAlwaysOnTop(!TopMost);
        }
    }
}
