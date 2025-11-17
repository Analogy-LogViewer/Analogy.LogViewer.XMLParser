using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Analogy.CommonUtilities.UI
{
    public partial class CommonLogSettingsUC : UserControl
    {
        private ILogParserSettings ParserSettings { get; set; }
        private AnalogyPropertiesMatcherUC Properties { get; set; }
        public CommonLogSettingsUC()
        {
            InitializeComponent();
            Properties = new AnalogyPropertiesMatcherUC();
            ParserSettings = new LogParserSettings();
        }

        public CommonLogSettingsUC(ILogParserSettings parserSettings)
        {
            ParserSettings = parserSettings;
            InitializeComponent();
            Properties = new AnalogyPropertiesMatcherUC(parserSettings);
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Analogy Log Parser Settings (*.AnalogySettings)|*.AnalogySettings";
            openFileDialog1.Title = @"Import Json Parser settings";
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog1.FileName);
                    ParserSettings = System.Text.Json.JsonSerializer.Deserialize<LogParserSettings>(json);
                    LoadJsonSettings();
                    MessageBox.Show("File Imported. Save settings if desired", @"Import settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Import: " + ex.Message, @"Error Import file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void LoadJsonSettings()
        {
            if (ParserSettings.IsConfigured)
            {
                txtLogExtension.Text = string.Join(";", ParserSettings.SupportedFilesExtensions);
                txtbLogDirectory.Text = ParserSettings.Directory;
            }
        }

        private void btnExportSettings_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Analogy Log Parser Settings (*.AnalogyJsonSettings)|*.AnalogyJsonSettings";
            saveFileDialog.Title = @"Export Json Parser settings";

            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog.FileName, System.Text.Json.JsonSerializer.Serialize(ParserSettings));
                    MessageBox.Show("File Saved", @"Export settings", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Export: " + ex.Message, @"Error Saving file", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void txtLogExtension_TextChanged(object sender, EventArgs e)
        {
            ParserSettings.SupportedFilesExtensions = txtLogExtension.Text.Split(';').ToList();
        }

        private void txtbLogDirectory_TextChanged(object sender, EventArgs e)
        {
            ParserSettings.Directory = txtbLogDirectory.Text;
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            ParserSettings.IsConfigured = true;
        }

        private void CommonLogSettingsUC_Load(object sender, EventArgs e)
        {
            pnlFill.Controls.Add(Properties);
            Properties.Dock = DockStyle.Fill;
            LoadJsonSettings();
        }

        public void SetExtensions(List<string> extensions)
        {
            if (extensions != null && extensions.Any())
            {
                ParserSettings.SupportedFilesExtensions = extensions;
                txtLogExtension.Text = string.Join(";", ParserSettings.SupportedFilesExtensions);
            }
        }
        public void SetDefaultDirectory(string dir)
        {
            ParserSettings.Directory = dir;
            txtbLogDirectory.Text = dir;
        }
    }
}