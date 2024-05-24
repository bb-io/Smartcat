using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class DocumentStatusDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "Created", "Created" },
            { "InProgress", "In progress" },
            { "Completed", "Completed" },
            { "Updated", "Updated" },
            { "TargetUpdated", "Target updated" },
        };
    }
}