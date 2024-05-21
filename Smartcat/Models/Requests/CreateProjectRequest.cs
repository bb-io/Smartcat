using Apps.Smartcat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
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

    [Display("Source Language")]
    public string SourceLanguage { get; set; }

    [Display("Target Languages")]
    public IEnumerable<string> TargetLanguages { get; set; }

    [Display("Client ID")]
    public string ClientId { get; set; }

    [Display("Assign to Vendor?")]
    public bool assignToVendor { get; set; }

    [Display("is Test?")]
    public bool? isForTesting { get; set; }

    [Display("External Tag")]
    public string? ExternalTag { get; set; }

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
                targetLanguages = TargetLanguages.Select(t => t).ToArray()

            } 
            , new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
    }
}