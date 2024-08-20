
using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Newtonsoft.Json;

namespace Apps.Smartcat.Models.Requests;

public class DownloadFileRequest
{
    [Display("Segment export mode")]
    [JsonProperty("mode")]
    [StaticDataSource(typeof(DownloadFileModeDataHandler))]
    public string? Mode { get; set; }

    [Display("Export document request type")]
    [JsonProperty("type")]
    [StaticDataSource(typeof(FileTypeDataHandler))]
    public string? Type { get; set; }

    [Display("Workflow stage number")]
    [JsonProperty("stageNumber")]
    public string? StageNumber { get; set; }

    [Display("Exporting file format")]
    [JsonProperty("exportingDocumentFormat")]
    [StaticDataSource(typeof(DocumentExportFormatHandler))]
    public string? ExportingDocumentFormat { get; set; }

    [Display("Structuring Delimiter")]
    [JsonProperty("structuringDelimiter")]
    public string? StructuringDelimiter { get; set; }

}