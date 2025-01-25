using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.LogViewer.Template.Managers;
using Analogy.LogViewer.XMLParser.Managers;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Analogy.LogViewer.XMLParser.IAnalogy
{
    public class XMLDataProvider : Template.OfflineDataProvider
    {
        public override string OptionalTitle { get; set; } = "Analogy XML Text Parser";

        public override Guid Id { get; set; } = new Guid("1DA46386-5604-449E-87FB-7D1036A85978");
        public override Image? LargeImage { get; set; }
        public override Image? SmallImage { get; set; }

        public override bool CanSaveToLogFile { get; set; }
        public override string FileOpenDialogFilters { get; set; } = "XML log files|*.xml";
        public override string FileSaveDialogFilters { get; set; } = string.Empty;
        public override IEnumerable<string> SupportFormats { get; set; } = new[] { "*.xml" };
        public override bool DisableFilePoolingOption { get; set; }
        public override string InitialFolderFullPath => Directory.Exists(UserSettings?.Directory)
            ? UserSettings.Directory
            : Environment.CurrentDirectory;
        public Parser Parser { get; set; }

        private ILogParserSettings UserSettings { get; set; }
        public override bool UseCustomColors { get; set; }
        public override IEnumerable<(string OriginalHeader, string ReplacementHeader)> GetReplacementHeaders()
            => Array.Empty<(string, string)>();

        public override (Color BackgroundColor, Color ForegroundColor) GetColorForMessage(IAnalogyLogMessage logMessage)
            => (Color.Empty, Color.Empty);
        public XMLDataProvider(ILogParserSettings userSettings)
        {
            UserSettings = userSettings;
        }
        public override Task InitializeDataProvider(ILogger logger)
        {
            LogManager.Instance.SetLogger(logger);
            Parser = new Parser(UserSettingsManager.UserSettings.LogParserSettings);
            return base.InitializeDataProvider(logger);
        }

        public override void MessageOpened(IAnalogyLogMessage message)
        {
            //nop
        }
        public override async Task<IEnumerable<IAnalogyLogMessage>> Process(string fileName, CancellationToken token, ILogMessageCreatedHandler messagesHandler)
        {
            if (CanOpenFile(fileName))
            {
                return await Parser.Process(fileName, token, messagesHandler);
            }

            return new List<AnalogyLogMessage>(0);
        }

        public override Task SaveAsync(List<IAnalogyLogMessage> messages, string fileName)
        {
            return Task.CompletedTask;
        }

        public override bool CanOpenFile(string fileName) => UserSettingsManager.UserSettings.LogParserSettings.CanOpenFile(fileName);

        public override bool CanOpenAllFiles(IEnumerable<string> fileNames) => fileNames.All(CanOpenFile);

        protected override List<FileInfo> GetSupportedFilesInternal(DirectoryInfo dirInfo, bool recursive)
        {
            List<FileInfo> files = dirInfo.GetFiles("*.*")
                .Where(f => UserSettings.CanOpenFile(f.FullName)).ToList();
            if (!recursive)
            {
                return files;
            }

            try
            {
                foreach (DirectoryInfo dir in dirInfo.GetDirectories())
                {
                    files.AddRange(GetSupportedFilesInternal(dir, true));
                }
            }
            catch (Exception)
            {
                return files;
            }

            return files;
        }
    }
}