using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class FileTypeDataHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            { "Source", "Source" },
            { "Target", "Target" },
            { "Xliff", "XLIFF" },
            { "MultilangCsv", "Multilang CSV" },
            { "DocumentWithMetadata", "Document with metadata" },
            { "SourceInNewFormat", "Source in new format" },
            { "SubtitlesBurningSource", "Subtitles burning source" },
            { "SubtitlesBurningTarget", "Subtitles burning target" },
        };
    }
}