using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class ProjectStatusDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "Created", "Created" },
            { "InProgress", "In progress" },
            { "Completed", "Completed" },
            { "Canceled", "Canceled" },
        };
    }
}