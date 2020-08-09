using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.XMLParser.Managers;
using Analogy.LogViewer.XMLParser.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.LogViewer.XMLParser.IAnalogy
{
    public class AnalogyXMLFactory : IAnalogyFactory
    {
        internal static Guid xmlFactoryId = new Guid("9652600E-1B14-4812-BCEC-9A6194DB9AEA");
        public Guid FactoryId { get; } = xmlFactoryId;
        public string Title { get; } = "XML Text Parser";
        public IEnumerable<IAnalogyChangeLog> ChangeLog => LogViewer.XMLParser.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "XML Text Parser";
    }

    public class AnalogyXMLDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; } = AnalogyXMLFactory.xmlFactoryId;
        public string Title { get; } = "XML Data Provider";
        public IEnumerable<IAnalogyDataProvider> DataProviders { get; } = new List<IAnalogyDataProvider>()
        {
            new XMLDataProvider(UserSettingsManager.UserSettings.LogParserSettings)
        };
    }

    public class AnalogyXMLCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; } = AnalogyXMLFactory.xmlFactoryId;
        public string Title { get; } = "XML Text tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; } = new List<IAnalogyCustomAction>(0);
    }

    public class AnalogyxmlSettings : IAnalogyDataProviderSettings
    {

        public Guid ID { get; set; } = new Guid("AEE7B966-3A32-445B-8A4C-1BAD40624ABB");
        public Guid FactoryId { get; set; } = AnalogyXMLFactory.xmlFactoryId;
        public string Title { get; } = "XML Text Settings";
        public UserControl DataProviderSettings { get; }= new CommonLogSettingsUC(UserSettingsManager.UserSettings.LogParserSettings);
        public Image SmallImage { get; }
        public Image LargeImage { get; } = Resources.xml32x32;

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}