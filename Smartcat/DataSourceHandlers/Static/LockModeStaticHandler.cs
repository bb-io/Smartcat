using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class LockModeStaticHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            ["None"] = "None",
            ["ByStates"] = "By states",
            ["Confirmed"] = "Confirmed",
        };
    }
}