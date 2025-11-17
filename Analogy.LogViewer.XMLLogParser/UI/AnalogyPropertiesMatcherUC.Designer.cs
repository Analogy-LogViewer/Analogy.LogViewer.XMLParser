using System.Windows.Forms;

namespace Analogy.CommonUtilities.UI
{
    partial class AnalogyPropertiesMatcherUC
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
            this.cbLogProperties = new System.Windows.Forms.ComboBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.lstbMappedKeys = new System.Windows.Forms.ListBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnAddKey = new System.Windows.Forms.Button();
            this.btnDeleteSelection = new System.Windows.Forms.Button();
            this.lblSelection = new System.Windows.Forms.Label();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLogProperties
            // 
            this.cbLogProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLogProperties.FormattingEnabled = true;
            this.cbLogProperties.Location = new System.Drawing.Point(286, 5);
            this.cbLogProperties.Name = "cbLogProperties";
            this.cbLogProperties.Size = new System.Drawing.Size(399, 24);
            this.cbLogProperties.TabIndex = 11;
            // 
            // lblLog
            // 
            this.lblLog.Location = new System.Drawing.Point(14, 8);
            this.lblLog.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(173, 20);
            this.lblLog.TabIndex = 12;
            this.lblLog.Text = "Analogy Log Properties:";
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label2);
            this.pnlTop.Controls.Add(this.txtKey);
            this.pnlTop.Controls.Add(this.cbLogProperties);
            this.pnlTop.Controls.Add(this.lblLog);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(688, 70);
            this.pnlTop.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Add key/property:";
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Location = new System.Drawing.Point(286, 39);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(298, 22);
            this.txtKey.TabIndex = 14;
            // 
            // lstbMappedKeys
            // 
            this.lstbMappedKeys.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstbMappedKeys.FormattingEnabled = true;
            this.lstbMappedKeys.ItemHeight = 16;
            this.lstbMappedKeys.Location = new System.Drawing.Point(6, 102);
            this.lstbMappedKeys.Name = "lstbMappedKeys";
            this.lstbMappedKeys.Size = new System.Drawing.Size(183, 292);
            this.lstbMappedKeys.TabIndex = 14;
            this.lstbMappedKeys.SelectedIndexChanged += new System.EventHandler(this.lstbMappedKeys_SelectedIndexChanged);
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInfo.Location = new System.Drawing.Point(3, 75);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(685, 25);
            this.lblInfo.TabIndex = 15;
            this.lblInfo.Text = "Log files keys/properties to map to:";
            // 
            // btnAddKey
            // 
            this.btnAddKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddKey.Location = new System.Drawing.Point(590, 35);
            this.btnAddKey.Name = "btnAddKey";
            this.btnAddKey.Size = new System.Drawing.Size(98, 32);
            this.btnAddKey.TabIndex = 16;
            this.btnAddKey.Text = "Add";
            this.btnAddKey.UseVisualStyleBackColor = true;
            this.btnAddKey.Click += new System.EventHandler(this.btnAddKey_Click);
            // 
            // btnDeleteSelection
            // 
            this.btnDeleteSelection.Location = new System.Drawing.Point(206, 135);
            this.btnDeleteSelection.Name = "btnDeleteSelection";
            this.btnDeleteSelection.Size = new System.Drawing.Size(148, 32);
            this.btnDeleteSelection.TabIndex = 17;
            this.btnDeleteSelection.Text = "Delete Selected";
            this.btnDeleteSelection.UseVisualStyleBackColor = true;
            this.btnDeleteSelection.Click += new System.EventHandler(this.btnDeleteSelection_Click);
            // 
            // lblSelection
            // 
            this.lblSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelection.Location = new System.Drawing.Point(206, 105);
            this.lblSelection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblSelection.Name = "lblSelection";
            this.lblSelection.Size = new System.Drawing.Size(479, 25);
            this.lblSelection.TabIndex = 18;
            this.lblSelection.Text = "Selection:";
            // 
            // AnalogyPropertiesMatcherUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelection);
            this.Controls.Add(this.btnDeleteSelection);
            this.Controls.Add(this.btnAddKey);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lstbMappedKeys);
            this.Controls.Add(this.pnlTop);
            this.Name = "AnalogyPropertiesMatcherUC";
            this.Size = new System.Drawing.Size(688, 397);
            this.Load += new System.EventHandler(this.AnalogyPropertiesMatcherUC_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ComboBox cbLogProperties;
        private Label lblLog;
        private Panel pnlTop;
        private ListBox lstbMappedKeys;
        private Label lblInfo;
        private Button btnAddKey;
        private Label label2;
        private TextBox txtKey;
        private Button btnDeleteSelection;
        private Label lblSelection;
    }
}
