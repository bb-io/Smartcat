using Apps.Smartcat.DataSourceHandlers;
using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Newtonsoft.Json;

namespace Apps.Smartcat.Models.Requests;

public class CreateProjectRequest
{
    public string Name { get; set; }

    [DataSource(typeof(ProjectTypeDataHandler))]
    public string Type { get; set; }

    public string? Description { get; set; }

    public DateTime Deadline { get; set; }

    [Display("Source language")]
    [StaticDataSource(typeof(LanguageDataHandler))]
    public string SourceLanguage { get; set; }

    [Display("Target languages")]
    [StaticDataSource(typeof(LanguageDataHandler))]
    public IEnumerable<string> TargetLanguages { get; set; }

    [Display("Client ID")]
    [DataSource(typeof(ClientDataHandler))]
    public string? ClientId { get; set; }

    [Display("Assign to vendor?")]
    public bool assignToVendor { get; set; }

    [Display("is test?")]
    public bool? isForTesting { get; set; }

    [Display("External tag")]
    public string? ExternalTag { get; set; }

    [Display("Workflow stages")]
    [StaticDataSource(typeof(WorkflowStageStaticHandler))]
    public IEnumerable<string>? WorkflowStages { get; set; }

    [Display("Translation memory IDs (apply to all targets)")]
    [DataSource(typeof(TMDataHandler))]
    public IEnumerable<string>? TranslationMemoryIds { get; set; }

    public string GetSerializedRequest()
    {
        return JsonConvert.SerializeObject( new
            {
                name = Name,
                number = new { useTemplate =  false },
                description = Description,
                deadline = Deadline.ToString("yyyy-MM-ddTHH:mm:ss.000Z"),
                clientId = ClientId,
                externalTag = ExternalTag,
                assignToVendor = assignToVendor,
                isForTesting = isForTesting,
                sourceLanguage = SourceLanguage,
                targetLanguages = TargetLanguages.Select(t => t).ToArray(),
                workflowStages = WorkflowStages?.ToArray()

        } 
            , new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
    }
}