using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Analogy.Interfaces;

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
        public async Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token,
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
                return new List<AnalogyLogMessage> { empty };
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

            List<AnalogyLogMessage> messages = new List<AnalogyLogMessage>();
            try
            {
                string json = File.ReadAllText(fileName); 
                string xmlData = File.ReadAllText(fileName);
                Func<string, List<object>> parseData = (data) => ParserInternal(data);
                try
                {
                    var data = parseData(xmlData);

                }
                catch (Exception e)
                {
                    string data = TryFix(xmlData);
                    parseData(data);
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

        private List<object> ParserInternal(string data)
        {
            XDocument XMLDoc = XDocument.Parse(data);
            return new List<object>();
        }
    }
}
