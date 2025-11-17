using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Analogy.CommonUtilities.UI
{
    public partial class AnalogyPropertiesMatcherUC : UserControl
    {
        private AnalogyLogMessagePropertyName Selection { get; set; }
        private ILogParserSettings ParserSettings { get; set; }
        public AnalogyPropertiesMatcherUC()
        {
            InitializeComponent();
            ParserSettings = new LogParserSettings();
        }

        public AnalogyPropertiesMatcherUC(ILogParserSettings parserSettings) : this()
        {
            ParserSettings = parserSettings;
        }
        private void AnalogyPropertiesMatcherUC_Load(object sender, EventArgs e)
        {
            cbLogProperties.DataSource = AnalogyLogMessage.LogMessagePropertyNames.Values.ToList();
            cbLogProperties.DropDownStyle = ComboBoxStyle.DropDownList;
            Selection = (AnalogyLogMessagePropertyName)cbLogProperties.SelectedItem;
            UpdateMappings();
            cbLogProperties.SelectedIndexChanged += this.cbLogProperties_SelectedIndexChanged;
        }

        private void cbLogProperties_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Selection = (AnalogyLogMessagePropertyName)cbLogProperties.SelectedItem;
            lblInfo.Text = $"Log files keys/properties to map to {Selection}:";
            UpdateMappings();
        }

        private void UpdateMappings()
        {
            if (ParserSettings.Maps.TryGetValue(Selection, out List<string>? value))
            {
                lstbMappedKeys.Items.Clear();
                lstbMappedKeys.Items.AddRange(value.ToArray());
            }
        }

        private void btnAddKey_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtKey.Text))
            {
                ParserSettings.AddMap(Selection, txtKey.Text);
                UpdateMappings();
            }
        }

        private void lstbMappedKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblSelection.Text = "Selection:" + lstbMappedKeys.SelectedItem;
        }

        private void btnDeleteSelection_Click(object sender, EventArgs e)
        {
            if (lstbMappedKeys.SelectedItem != null)
            {
                ParserSettings.DeleteMap(Selection, (string)lstbMappedKeys.SelectedItem);
                UpdateMappings();
            }
        }
    }
}