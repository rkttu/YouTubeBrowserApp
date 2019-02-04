namespace AccuRadioBrowserApp
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
            this.RememberWindowBoundCheckBox = new System.Windows.Forms.CheckBox();
            this.RememberLastPageCheckBox = new System.Windows.Forms.CheckBox();
            this.DialogCancelButton = new System.Windows.Forms.Button();
            this.DialogOkayButton = new System.Windows.Forms.Button();
            this.AlwaysOnTopCheckBox = new System.Windows.Forms.CheckBox();
            this.AboutButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RememberWindowBoundCheckBox
            // 
            resources.ApplyResources(this.RememberWindowBoundCheckBox, "RememberWindowBoundCheckBox");
            this.RememberWindowBoundCheckBox.Name = "RememberWindowBoundCheckBox";
            this.RememberWindowBoundCheckBox.UseVisualStyleBackColor = true;
            // 
            // RememberLastPageCheckBox
            // 
            resources.ApplyResources(this.RememberLastPageCheckBox, "RememberLastPageCheckBox");
            this.RememberLastPageCheckBox.Name = "RememberLastPageCheckBox";
            this.RememberLastPageCheckBox.UseVisualStyleBackColor = true;
            // 
            // DialogCancelButton
            // 
            resources.ApplyResources(this.DialogCancelButton, "DialogCancelButton");
            this.DialogCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.DialogCancelButton.Name = "DialogCancelButton";
            this.DialogCancelButton.UseVisualStyleBackColor = true;
            // 
            // DialogOkayButton
            // 
            resources.ApplyResources(this.DialogOkayButton, "DialogOkayButton");
            this.DialogOkayButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DialogOkayButton.Name = "DialogOkayButton";
            this.DialogOkayButton.UseVisualStyleBackColor = true;
            // 
            // AlwaysOnTopCheckBox
            // 
            resources.ApplyResources(this.AlwaysOnTopCheckBox, "AlwaysOnTopCheckBox");
            this.AlwaysOnTopCheckBox.Name = "AlwaysOnTopCheckBox";
            this.AlwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            // 
            // AboutButton
            // 
            resources.ApplyResources(this.AboutButton, "AboutButton");
            this.AboutButton.Name = "AboutButton";
            this.AboutButton.UseVisualStyleBackColor = true;
            this.AboutButton.Click += new System.EventHandler(this.AboutButton_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.DialogOkayButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.DialogCancelButton;
            this.Controls.Add(this.AboutButton);
            this.Controls.Add(this.DialogOkayButton);
            this.Controls.Add(this.DialogCancelButton);
            this.Controls.Add(this.AlwaysOnTopCheckBox);
            this.Controls.Add(this.RememberLastPageCheckBox);
            this.Controls.Add(this.RememberWindowBoundCheckBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox RememberWindowBoundCheckBox;
        private System.Windows.Forms.CheckBox RememberLastPageCheckBox;
        private System.Windows.Forms.Button DialogCancelButton;
        private System.Windows.Forms.Button DialogOkayButton;
        private System.Windows.Forms.CheckBox AlwaysOnTopCheckBox;
        private System.Windows.Forms.Button AboutButton;
    }
}