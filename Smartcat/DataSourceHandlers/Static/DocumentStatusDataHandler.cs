using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class DocumentStatusDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "InProgress", "In progress" },
            { "Completed", "Completed" },
        };
    }
}