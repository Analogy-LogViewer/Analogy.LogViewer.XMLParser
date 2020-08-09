using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Analogy.LogViewer.XMLFileProvider.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task TestMethod1()
        {
            string fileName = "defaultFile_2019_05_19_13_42_33.xml";
            ILogParserSettings lp = new LogParserSettings();
            lp.IsConfigured = true;
            lp.AddMap(AnalogyLogMessagePropertyName.Id,"ID");
            lp.SupportedFilesExtensions = new List<string>() { "*.xml" };
            var fp = new XMLParser.XMLParser(lp);
            CancellationTokenSource ts = new CancellationTokenSource();
            MessageHandlerForTesting handler = new MessageHandlerForTesting();
            await fp.Process(fileName, ts.Token, handler);
        }
    }
}
