
using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Requests
{
    public class DownloadFileRequest
    {
        [Display("Document ID")]
        public string DocumentId { get; set; }

        [Display("Language ID")]
        public string LanguageID { get; set; }

        [Display("Segment export mode")]
        public string? Mode { get; set; }

        [Display("Export document request type")]
        public string? Type { get; set; }

        [Display("Workflow stage number")]
        public string? stageNumber { get; set; }

        [Display("Exporting file format")]
        public string? exportingDocumentFormat { get; set; }

        [Display("Structuring Delimiter")]
        public string? structuringDelimiter { get; set; }

    }
}
