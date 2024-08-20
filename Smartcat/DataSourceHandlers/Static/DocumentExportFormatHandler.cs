using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class DocumentExportFormatHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "json", "JSON" },
            { "ios-strings", "IOS strings" },
            { "android-xml", "Android XML" },
            { "yaml", "YAML" },
            { "structured-json", "Structured JSON" },
            { "structured-yaml", "Structured YAML" },
        };
    }
}