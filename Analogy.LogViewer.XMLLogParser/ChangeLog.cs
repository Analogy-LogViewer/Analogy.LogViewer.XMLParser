using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;

namespace Analogy.LogViewer.XMLParser
{
    public static class ChangeLog
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            yield return new AnalogyChangeLog("Add Source Link To Project)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2020, 02, 28), "");
        }
    }
}