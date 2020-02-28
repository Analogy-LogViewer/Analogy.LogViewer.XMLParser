using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Analogy.Interfaces;

namespace Analogy.LogViewer.XMLLogParser
{
    public class XMLParser
    {
        private ILogParserSettings _logFileSettings;
        public XMLParser(ILogParserSettings logFileSettings)
        {
            _logFileSettings = logFileSettings;
        }

        public Task<IEnumerable<AnalogyLogMessage>> Process(string fileName, CancellationToken token,
            ILogMessageCreatedHandler messagesHandler)
        {
            string xmlData = File.ReadAllText(fileName);
            Func<string, List<object>> parseData = (data) => ParserInternal(data);
            try
            {
                var data=parseData(xmlData);
                return Task.FromResult(new List<AnalogyLogMessage>().AsEnumerable());

            }
            catch (Exception e)
            {
                string data = TryFix(xmlData);
                parseData(data);
            }
            return Task.FromResult(new List<AnalogyLogMessage>().AsEnumerable());
        }


        private string TryFix(string data)
        {
            string corrrected = $"<Array>{data}</Array>";
            return corrrected;
        }

        private List<object> ParserInternal(string data)
        {
            XDocument XMLDoc = XDocument.Parse(data);
            return new List<object>();
        }
    }
}
