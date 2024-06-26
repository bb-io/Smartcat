using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class TargetSubstitutionModeStaticHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            ["All"] = "All",
            ["None"] = "None",
        };
    }
}