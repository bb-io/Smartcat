using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Requests;

public class DocumentRequest
{
    [Display("File ID")]
    public string DocumentId { get; set; }
}