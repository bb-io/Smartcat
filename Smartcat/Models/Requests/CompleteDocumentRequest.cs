using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Requests
{
    public class CompleteDocumentRequest
    {
        [Display("Document ID")]
        public string DocumentId { get; set; }
    }
}
