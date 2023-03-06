using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;

namespace Analogy.LogViewer.XMLParser
{
    public class XMLParser
    {
        private ILogParserSettings _logFileSettings;
        public XMLParser(ILogParserSettings logFileSettings)
        {
            _logFileSettings = logFileSettings;
        }
        private static string GetFileNameAsDataSource(string fileName)
        {
            string file = Path.GetFileName(fileName);
            return fileName.Equals(file) ? fileName : $"{file} ({fileName})";

        }
        public async Task<IEnumerable<IAnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"File is null or empty. Aborting.",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty };
            }

            if (!_logFileSettings.IsConfigured)
            {
                AnalogyLogMessage empty = new AnalogyLogMessage(
                    $"File Parser is not configured. Please set it first in the settings Window",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, GetFileNameAsDataSource(fileName));
                return new List<IAnalogyLogMessage> { empty };
            }

            if (!_logFileSettings.CanOpenFile(fileName))
            {
                AnalogyLogMessage empty = new AnalogyLogMessage(
                    $"File {fileName} Is not supported or not configured correctly in the windows settings",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty };
            }

            List<IAnalogyLogMessage> messages = new List<IAnalogyLogMessage>();
            try
            {
                string xmlData = File.ReadAllText(fileName);
                List<List<(string, string)>> ParseData(string data) => ParserInternal(data);
                try
                {
                    var rows = ParseData(xmlData);
                    for (var i = 0; i < rows.Count; i++)
                    {
                        var items = rows[i];
                        List<(string, string)> tuples = new List<(string, string)>(items.Count);
                        foreach (var (key, value) in items)
                        {
                            var keyProperty = _logFileSettings.GetAnalogyPropertyName(key);
                            tuples.Add(keyProperty.HasValue
                                ? (keyProperty.Value.ToString(), value)
                                : (key, value));
                        }

                        var m = AnalogyLogMessage.Parse(tuples);
                        messages.Add(m);
                        messagesHandler.ReportFileReadProgress(
                            new AnalogyFileReadProgress(AnalogyFileReadProgressType.Incremental, 1, i, rows.Count));
                    }
                }
                catch (Exception e)
                {
                    string data = TryFix(xmlData);
                    ParseData(data);
                }

                messagesHandler.AppendMessages(messages, fileName);
                return messages;
            }
            catch (Exception e)
            {
                AnalogyLogMessage empty = new AnalogyLogMessage($"Error occured processing file {fileName}. Reason: {e.Message}",
                    AnalogyLogLevel.Critical, AnalogyLogClass.General, "Analogy", "None")
                {
                    Source = "Analogy",
                    Module = System.Diagnostics.Process.GetCurrentProcess().ProcessName
                };
                messagesHandler.AppendMessage(empty, GetFileNameAsDataSource(fileName));
                return new List<AnalogyLogMessage> { empty
    };
            }
        }


        private string TryFix(string data)
        {
            string corrected = $"<Array>{data}</Array>";
            return corrected;
        }

        private List<List<(string, string)>> ParserInternal(string data)
        {
            var items = new List<List<(string, string)>>();
            var doc = new XmlDocument();
            doc.LoadXml(data);
            doc.IterateThroughAllNodes(
                node =>
                {
                    var inner = new List<(string, string)>();
                    var xr = new XmlNodeReader(node);
                    while (xr.Read())
                    {
                        while (xr.Read())
                        {
                            while (xr.IsStartElement())
                            {
                                inner.Add((xr.Name, xr.ReadElementContentAsString()));
                            }
                        }
                    }

                    items.Add(inner);

                });
            return items;
        }
    }
}
