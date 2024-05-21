using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Requests;

public class DocumentRequest
{
    [Display("Document ID")]
    public string DocumentId { get; set; }

    [Display("Language ID")]
    public string LanguageID { get; set; }
}