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
        internal static Guid xmlFactory = new Guid("9652600E-1B14-4812-BCEC-9A6194DB9AEA");
        public Guid FactoryId { get; } = xmlFactory;
        public string Title { get; } = "Analogy XML Text Parser";
        public IEnumerable<IAnalogyChangeLog> ChangeLog => LogViewer.XMLParser.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> { "Lior Banai" };
        public string About { get; } = "Analogy XML Text Parser";
    }

    public class AnalogyXMLDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public Guid FactoryId { get; } = AnalogyXMLFactory.xmlFactory;
        public string Title { get; } = "Analogy XML Data Provider";
        public IEnumerable<IAnalogyDataProvider> DataProviders { get; } = new List<IAnalogyDataProvider>()
        {
            new XMLDataProvider(UserSettingsManager.UserSettings.LogParserSettings)
        };
    }

    public class AnalogyXMLCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; } = AnalogyXMLFactory.xmlFactory;
        public string Title { get; } = "Analogy XML Text tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; } = new List<IAnalogyCustomAction>(0);
    }

    public class AnalogyxmlSettings : IAnalogyDataProviderSettings
    {

        public Guid ID { get; } = new Guid("AEE7B966-3A32-445B-8A4C-1BAD40624ABB");
        public Guid FactoryId { get; set; } = AnalogyXMLFactory.xmlFactory;
        public string Title { get; } = "Plain Text Settings";
        public UserControl DataProviderSettings { get; } = new XMLUserControlSettings();
        public Image SmallImage { get; }
        public Image LargeImage { get; } = Resources.xml32x32;

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}