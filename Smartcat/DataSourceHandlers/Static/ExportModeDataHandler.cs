using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static
{
    public class ExportModeDataHandler : IStaticDataSourceHandler
    {
        public Dictionary<string, string> GetData()
        {
            return new()
            {
                ["TmxDefault"] = "Tmx default",
                ["TmxWithTrados2009PlusCompatibility"] = "Tmx with trados 2009 compitabolity",
                ["TmxWithTrados2007Compatibility"]= "Tmx with trados 2007 compitabolity",
                ["Excel"] = "Excel"
            };
        }
    }
}
