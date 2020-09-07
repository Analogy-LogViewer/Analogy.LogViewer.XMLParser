using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.XMLParser.Managers;
using Analogy.LogViewer.XMLParser.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.CommonUtilities.UI;

namespace Analogy.LogViewer.XMLParser.IAnalogy
{
    public class AnalogyXMLFactory : IAnalogyFactory
    {
        internal static Guid xmlFactoryId = new Guid("9652600E-1B14-4812-BCEC-9A6194DB9AEA");
        public Guid FactoryId { get; set; } = xmlFactoryId;
        public string Title { get; set; } = "XML Text Parser";
        public IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = LogViewer.XMLParser.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public string About { get; set; } = "XML Text Parser";
        public Image LargeImage { get; set; } = Resources.xml32x32;
        public Image SmallImage { get; set; } = Resources.xml16x16;
    }

    public class AnalogyXMLDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; set; } = AnalogyXMLFactory.xmlFactoryId;
        public string Title { get; set; } = "XML Data Provider";
        public IEnumerable<IAnalogyDataProvider> DataProviders { get; } = new List<IAnalogyDataProvider>()
        {
            new XMLDataProvider(UserSettingsManager.UserSettings.LogParserSettings)
        };
    }

    public class AnalogyXMLCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; set; } = AnalogyXMLFactory.xmlFactoryId;
        public string Title { get; set; } = "XML Text tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; } = new List<IAnalogyCustomAction>(0);
    }

    public class AnalogyxmlSettings : IAnalogyDataProviderSettings
    {

        public Guid Id { get; set; } = new Guid("AEE7B966-3A32-445B-8A4C-1BAD40624ABB");
        public Guid FactoryId { get; set; } = AnalogyXMLFactory.xmlFactoryId;
        public string Title { get; set; } = "XML Text Settings";
        public UserControl DataProviderSettings { get; set; } = new CommonLogSettingsUC(UserSettingsManager.UserSettings.LogParserSettings);
        public Image SmallImage { get; set; } = Resources.xml16x16;
        public Image LargeImage { get; set; } = Resources.xml32x32;

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}