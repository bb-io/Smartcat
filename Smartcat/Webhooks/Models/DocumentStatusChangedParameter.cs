using Apps.Smartcat.DataSourceHandlers;
using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Smartcat.Webhooks.Models;

public class DocumentStatusChangedParameter
{
    [Display("Document ID")] public string? DocumentId { get; set; }

    [StaticDataSource(typeof(DocumentStatusDataHandler))]
    public string? Status { get; set; }

    [Display("Project ID"), DataSource(typeof(ProjectDataHandler))]
    public string? ProjectId { get; set; }
    
    [Display("Source language"), StaticDataSource(typeof(LanguageDataHandler))]
    public string? SourceLanguage { get; set; }

    [Display("Target language"), StaticDataSource(typeof(LanguageDataHandler))]
    public string? TargetLanguage { get; set; }
}