using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Analogy.LogViewer.XMLFileProvider
{
    public class XMLParser
    {

        public void ParserFile(string filename)
        {
            string xmlData = File.ReadAllText(filename);
            Func<string, List<object>> parseData = (data) => ParserInternal(data);
            try
            {
                parseData(xmlData);

            }
            catch (Exception e)
            {
                string data = TryFix(xmlData);
                parseData(data);
            }

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
