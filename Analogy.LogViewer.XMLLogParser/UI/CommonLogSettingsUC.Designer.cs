namespace Analogy.CommonUtilities.UI
{
    partial class CommonLogSettingsUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnOpenFolder = new System.Windows.Forms.Button();
            this.txtbLogDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLogExtension = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.btnExportSettings = new System.Windows.Forms.Button();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.btnOpenFolder);
            this.pnlTop.Controls.Add(this.txtbLogDirectory);
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.label3);
            this.pnlTop.Controls.Add(this.txtLogExtension);
            this.pnlTop.Controls.Add(this.btnImport);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(855, 67);
            this.pnlTop.TabIndex = 19;
            // 
            // btnOpenFolder
            // 
            this.btnOpenFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFolder.Location = new System.Drawing.Point(696, 31);
            this.btnOpenFolder.Name = "btnOpenFolder";
            this.btnOpenFolder.Size = new System.Drawing.Size(28, 25);
            this.btnOpenFolder.TabIndex = 13;
            this.btnOpenFolder.Text = "..";
            this.btnOpenFolder.UseVisualStyleBackColor = true;
            // 
            // txtbLogDirectory
            // 
            this.txtbLogDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbLogDirectory.Location = new System.Drawing.Point(228, 33);
            this.txtbLogDirectory.Name = "txtbLogDirectory";
            this.txtbLogDirectory.Size = new System.Drawing.Size(458, 22);
            this.txtbLogDirectory.TabIndex = 12;
            this.txtbLogDirectory.TextChanged += new System.EventHandler(this.txtbLogDirectory_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Log File Extensions (use ; as seperator):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Default Logs Location (optional)";
            // 
            // txtLogExtension
            // 
            this.txtLogExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogExtension.Location = new System.Drawing.Point(290, 5);
            this.txtLogExtension.Name = "txtLogExtension";
            this.txtLogExtension.Size = new System.Drawing.Size(431, 22);
            this.txtLogExtension.TabIndex = 9;
            this.txtLogExtension.Text = "*.log";
            this.txtLogExtension.TextChanged += new System.EventHandler(this.txtLogExtension_TextChanged);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(732, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(114, 25);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "Import settings";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSaveSettings);
            this.pnlBottom.Controls.Add(this.btnExportSettings);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 452);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(855, 46);
            this.pnlBottom.TabIndex = 20;
            // 
            // pnlFill
            // 
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 67);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(855, 385);
            this.pnlFill.TabIndex = 21;
            // 
            // btnExportSettings
            // 
            this.btnExportSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSettings.Location = new System.Drawing.Point(583, 6);
            this.btnExportSettings.Name = "btnExportSettings";
            this.btnExportSettings.Size = new System.Drawing.Size(126, 36);
            this.btnExportSettings.TabIndex = 11;
            this.btnExportSettings.Text = "Export settings";
            this.btnExportSettings.UseVisualStyleBackColor = true;
            this.btnExportSettings.Click += new System.EventHandler(this.btnExportSettings_Click);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSettings.Location = new System.Drawing.Point(715, 6);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(126, 36);
            this.btnSaveSettings.TabIndex = 12;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // CommonLogSettingsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "CommonLogSettingsUC";
            this.Size = new System.Drawing.Size(855, 498);
            this.Load += new System.EventHandler(this.CommonLogSettingsUC_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtbLogDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLogExtension;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnExportSettings;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.Button btnSaveSettings;
    }
}
