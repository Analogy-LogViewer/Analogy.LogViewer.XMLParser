using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;

namespace Analogy.LogViewer.XMLParser.Managers
{
    public class UserSettingsManager
    {
        private static readonly Lazy<UserSettingsManager> _instance =
            new Lazy<UserSettingsManager>(() => new UserSettingsManager());
        public static UserSettingsManager UserSettings { get; set; } = _instance.Value;
        private string NLogFileSetting { get; } = "AnalogyXMLTextSettings.json";
        public ILogParserSettings LogParserSettings { get; set; }

        public UserSettingsManager()
        {
            if (File.Exists(NLogFileSetting))
            {
                try
                {
                    string data = File.ReadAllText(NLogFileSetting);
                    LogParserSettings = System.Text.Json.JsonSerializer.Deserialize<LogParserSettings>(data);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogError(ex, "Error loading user setting file", ex, "XML Provider");
                    LogParserSettings = new LogParserSettings();
                    LogParserSettings.SupportedFilesExtensions = new List<string> { "*.xml" };
                }
            }
            else
            {
                LogParserSettings = new LogParserSettings();
                LogParserSettings.SupportedFilesExtensions = new List<string> { "*.xml" };
            }
        }

        public void Save()
        {
            try
            {
                File.WriteAllText(NLogFileSetting, System.Text.Json.JsonSerializer.Serialize(LogParserSettings));
            }
            catch (Exception e)
            {
                LogManager.Instance.LogError(e, "Error saving XML parser settings", e, "XML parser");
            }
        }
    }
}