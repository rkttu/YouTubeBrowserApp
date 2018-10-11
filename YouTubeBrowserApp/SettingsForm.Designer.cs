namespace YouTubeBrowserApp
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.RememberWindowBound = new System.Windows.Forms.CheckBox();
            this.RememberLastPage = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // RememberWindowBound
            // 
            this.RememberWindowBound.AutoSize = true;
            this.RememberWindowBound.Location = new System.Drawing.Point(13, 13);
            this.RememberWindowBound.Name = "RememberWindowBound";
            this.RememberWindowBound.Size = new System.Drawing.Size(319, 16);
            this.RememberWindowBound.TabIndex = 0;
            this.RememberWindowBound.Text = "Remember window bound (location, size and state)";
            this.RememberWindowBound.UseVisualStyleBackColor = true;
            // 
            // RememberLastPage
            // 
            this.RememberLastPage.AutoSize = true;
            this.RememberLastPage.Location = new System.Drawing.Point(13, 44);
            this.RememberLastPage.Name = "RememberLastPage";
            this.RememberLastPage.Size = new System.Drawing.Size(186, 16);
            this.RememberLastPage.TabIndex = 1;
            this.RememberLastPage.Text = "Remember last viewed page";
            this.RememberLastPage.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(464, 81);
            this.Controls.Add(this.RememberLastPage);
            this.Controls.Add(this.RememberWindowBound);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 120);
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox RememberWindowBound;
        private System.Windows.Forms.CheckBox RememberLastPage;
    }
}