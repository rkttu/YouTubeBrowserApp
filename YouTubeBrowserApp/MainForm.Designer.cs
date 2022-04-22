namespace YouTubeBrowserApp
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyIconContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RestoreWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AlwaysOntopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.AboutAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.BackButton = new System.Windows.Forms.ToolStripButton();
            this.NextButton = new System.Windows.Forms.ToolStripButton();
            this.TitleLabel = new YouTubeBrowserApp.ToolStripSpringLabel();
            this.CloseButton = new System.Windows.Forms.ToolStripButton();
            this.MaximizeButton = new System.Windows.Forms.ToolStripButton();
            this.MinimizeButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.SettingsButton = new System.Windows.Forms.ToolStripButton();
            this.WebView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.NotifyIconContextMenuStrip.SuspendLayout();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebView)).BeginInit();
            this.SuspendLayout();
            // 
            // NotifyIcon
            // 
            resources.ApplyResources(this.NotifyIcon, "NotifyIcon");
            this.NotifyIcon.ContextMenuStrip = this.NotifyIconContextMenuStrip;
            this.NotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseClick);
            // 
            // NotifyIconContextMenuStrip
            // 
            this.NotifyIconContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestoreWindowToolStripMenuItem,
            this.AlwaysOntopToolStripMenuItem,
            this.toolStripMenuItem1,
            this.AboutAppToolStripMenuItem,
            this.CloseAppToolStripMenuItem});
            this.NotifyIconContextMenuStrip.Name = "NotifyIconContextMenuStrip";
            resources.ApplyResources(this.NotifyIconContextMenuStrip, "NotifyIconContextMenuStrip");
            // 
            // RestoreWindowToolStripMenuItem
            // 
            this.RestoreWindowToolStripMenuItem.Name = "RestoreWindowToolStripMenuItem";
            resources.ApplyResources(this.RestoreWindowToolStripMenuItem, "RestoreWindowToolStripMenuItem");
            this.RestoreWindowToolStripMenuItem.Click += new System.EventHandler(this.RestoreWindowToolStripMenuItem_Click);
            // 
            // AlwaysOntopToolStripMenuItem
            // 
            this.AlwaysOntopToolStripMenuItem.Name = "AlwaysOntopToolStripMenuItem";
            resources.ApplyResources(this.AlwaysOntopToolStripMenuItem, "AlwaysOntopToolStripMenuItem");
            this.AlwaysOntopToolStripMenuItem.Click += new System.EventHandler(this.AlwaysOntopToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // AboutAppToolStripMenuItem
            // 
            this.AboutAppToolStripMenuItem.Name = "AboutAppToolStripMenuItem";
            resources.ApplyResources(this.AboutAppToolStripMenuItem, "AboutAppToolStripMenuItem");
            this.AboutAppToolStripMenuItem.Click += new System.EventHandler(this.AboutAppToolStripMenuItem_Click);
            // 
            // CloseAppToolStripMenuItem
            // 
            this.CloseAppToolStripMenuItem.Name = "CloseAppToolStripMenuItem";
            resources.ApplyResources(this.CloseAppToolStripMenuItem, "CloseAppToolStripMenuItem");
            this.CloseAppToolStripMenuItem.Click += new System.EventHandler(this.CloseAppToolStripMenuItem_Click);
            // 
            // ToolStrip
            // 
            this.ToolStrip.BackColor = System.Drawing.SystemColors.Window;
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BackButton,
            this.NextButton,
            this.TitleLabel,
            this.CloseButton,
            this.MaximizeButton,
            this.MinimizeButton,
            this.RefreshButton,
            this.SettingsButton});
            resources.ApplyResources(this.ToolStrip, "ToolStrip");
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolStrip.Stretch = true;
            // 
            // BackButton
            // 
            this.BackButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.BackButton, "BackButton");
            this.BackButton.Name = "BackButton";
            this.BackButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NextButton
            // 
            this.NextButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.NextButton, "NextButton");
            this.NextButton.Name = "NextButton";
            this.NextButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // TitleLabel
            // 
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            resources.ApplyResources(this.TitleLabel, "TitleLabel");
            this.TitleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleLabel_MouseDown);
            // 
            // CloseButton
            // 
            this.CloseButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CloseButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.CloseButton, "CloseButton");
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // MaximizeButton
            // 
            this.MaximizeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MaximizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.MaximizeButton, "MaximizeButton");
            this.MaximizeButton.Name = "MaximizeButton";
            this.MaximizeButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.MaximizeButton.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.MinimizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.MinimizeButton, "MinimizeButton");
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.RefreshButton, "RefreshButton");
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SettingsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.SettingsButton, "SettingsButton");
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // WebView
            // 
            this.WebView.AllowExternalDrop = true;
            this.WebView.CreationProperties = null;
            this.WebView.DefaultBackgroundColor = System.Drawing.Color.White;
            resources.ApplyResources(this.WebView, "WebView");
            this.WebView.Name = "WebView";
            this.WebView.ZoomFactor = 1D;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.WebView);
            this.Controls.Add(this.ToolStrip);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.NotifyIconContextMenuStrip.ResumeLayout(false);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WebView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyIconContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RestoreWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem CloseAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutAppToolStripMenuItem;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton BackButton;
        private System.Windows.Forms.ToolStripButton NextButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private ToolStripSpringLabel TitleLabel;
        private System.Windows.Forms.ToolStripButton CloseButton;
        private System.Windows.Forms.ToolStripButton MinimizeButton;
        private System.Windows.Forms.ToolStripButton MaximizeButton;
        private System.Windows.Forms.ToolStripButton SettingsButton;
        private System.Windows.Forms.ToolStripMenuItem AlwaysOntopToolStripMenuItem;
        private Microsoft.Web.WebView2.WinForms.WebView2 WebView;
    }
}

