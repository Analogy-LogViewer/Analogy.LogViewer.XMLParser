using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Analogy.DataProviders.Extensions;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;
using Analogy.LogViewer.XMLParser.Managers;
using Analogy.LogViewer.XMLParser.Properties;

namespace Analogy.LogViewer.XMLParser.IAnalogy
{
    public class AnalogyXMLFactory : IAnalogyFactory
    {
        public Guid FactoryID { get; } = new Guid("9652600E-1B14-4812-BCEC-9A6194DB9AEA");
        public string Title { get; } = "Analogy XML Text Parser";
        public IAnalogyDataProvidersFactory DataProviders { get; }
        public IAnalogyCustomActionsFactory Actions { get; }
        public IEnumerable<IAnalogyChangeLog> ChangeLog => LogViewer.XMLParser.ChangeLog.GetChangeLog();
        public IEnumerable<string> Contributors { get; } = new List<string> {"Lior Banai"};
        public string About { get; } = "Analogy XML Text Parser";

        public AnalogyXMLFactory()
        {
            DataProviders = new AnalogyXMLDataProviderFactory();
            Actions = new AnalogyXMLCustomActionFactory();

        }


    }

    public class AnalogyXMLDataProviderFactory : IAnalogyDataProvidersFactory
    {
        public string Title { get; } = "Analogy XML Data Provider";
        public IEnumerable<IAnalogyDataProvider> Items { get; }

        public AnalogyXMLDataProviderFactory()
        {
            var builtInItems = new List<IAnalogyDataProvider>()
            {
                new XMLDataProvider(UserSettingsManager.UserSettings.LogParserSettings)
            };
           Items = builtInItems;
        }
    }

    public class AnalogyXMLCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public string Title { get; } = "Analogy XML Text tools";
        public IEnumerable<IAnalogyCustomAction> Items { get; }

        public AnalogyXMLCustomActionFactory()
        {
            Items = new List<IAnalogyCustomAction>(0);
        }
    }

    public class AnalogyxmlSettings : IAnalogyDataProviderSettings
    {

        public Guid ID { get; } = new Guid("AEE7B966-3A32-445B-8A4C-1BAD40624ABB");

        public string Title { get; } = "Plain Text Settings";
        public UserControl DataProviderSettings { get; } = new XMLUserControlSettings();
        public Image Icon { get; } = Resources.xml32x32;

        public Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}