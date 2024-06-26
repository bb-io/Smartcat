using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class ConfirmModeStaticHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            ["None"] = "None",
            ["ByStates"] = "By states",
            ["AtFirstStage"] = "At first stage",
            ["AtLastStage"] = "At last stage",
        };
    }
}