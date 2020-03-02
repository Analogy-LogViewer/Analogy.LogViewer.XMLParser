using System;
using System.Collections.Generic;
using System.IO;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Newtonsoft.Json;

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
                    LogParserSettings = JsonConvert.DeserializeObject<LogParserSettings>(data);
                }
                catch (Exception ex)
                {
                    LogManager.Instance.LogException(ex, "XML Provider", "Error loading user setting file");
                    LogParserSettings = new LogParserSettings();
                    LogParserSettings.Splitter = "|";
                    LogParserSettings.SupportedFilesExtensions = new List<string> { "*.xml" };
                }
            }
            else
            {
                LogParserSettings = new LogParserSettings();
                LogParserSettings.Splitter = "|";
                LogParserSettings.SupportedFilesExtensions = new List<string> { "*.xml" };

            }

        }

        public void Save()
        {
            try
            {
                File.WriteAllText(NLogFileSetting, JsonConvert.SerializeObject(LogParserSettings));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }
    }
}
