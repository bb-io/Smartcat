using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class DownloadFileModeDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "Current", "Current" },
            { "Confirmed", "Confirmed" },
            { "Complete", "Complete" }
        };
    }
}