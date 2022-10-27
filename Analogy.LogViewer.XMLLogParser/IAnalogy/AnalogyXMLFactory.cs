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
    public class AnalogyXMLFactory : Template.PrimaryFactory
    {
        internal static Guid Id = new Guid("9652600E-1B14-4812-BCEC-9A6194DB9AEA");

        public override Guid FactoryId { get; set; } = Id;
        public override string Title { get; set; } = "XML Text Parser";
        public override IEnumerable<IAnalogyChangeLog> ChangeLog { get; set; } = LogViewer.XMLParser.ChangeLog.GetChangeLog();
        public override IEnumerable<string> Contributors { get; set; } = new List<string> { "Lior Banai" };
        public override string About { get; set; } = "XML Text Parser";
        public override Image? LargeImage { get; set; } = Resources.xml32x32;
        public override Image? SmallImage { get; set; } = Resources.xml16x16;
    }

    public class AnalogyXMLDataProviderFactory : Template.DataProvidersFactory
    {
        public override Guid FactoryId { get; set; } = AnalogyXMLFactory.Id;
        public override string Title { get; set; } = "XML Data Provider";
        public override IEnumerable<IAnalogyDataProvider> DataProviders { get; set; } = new List<IAnalogyDataProvider>()
        {
            new XMLDataProvider(UserSettingsManager.UserSettings.LogParserSettings)
        };
    }

    public class AnalogyXMLCustomActionFactory : IAnalogyCustomActionsFactory
    {
        public Guid FactoryId { get; set; } = AnalogyXMLFactory.Id;
        public string Title { get; set; } = "XML Text tools";
        public IEnumerable<IAnalogyCustomAction> Actions { get; } = new List<IAnalogyCustomAction>(0);
    }

    public class AnalogyxmlSettings : Template.TemplateUserSettingsFactory
    {

        public override Guid Id { get; set; } = new Guid("AEE7B966-3A32-445B-8A4C-1BAD40624ABB");
        public override Guid FactoryId { get; set; } = AnalogyXMLFactory.Id;
        public override string Title { get; set; } = "XML Text Settings";
        public override UserControl DataProviderSettings { get; set; } 
        public override Image? SmallImage { get; set; } = Resources.xml16x16;
        public override Image? LargeImage { get; set; } = Resources.xml32x32;

        public override void CreateUserControl(IAnalogyLogger logger)
        {
            DataProviderSettings = new CommonLogSettingsUC(UserSettingsManager.UserSettings.LogParserSettings);
        }

        public override Task SaveSettingsAsync()
        {
            UserSettingsManager.UserSettings.Save();
            return Task.CompletedTask;
        }

    }
}