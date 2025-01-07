using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Smartcat.Models.Requests
{
    public class UploadXLIFFRequest
    {
        [Display("Document ID")]
        public string DocumentID { get; set; }
        public FileReference File { get; set; }

        [Display("Overwrite translations")]
        public bool? Overwrite { get; set; }

        [Display("Confirm updated segments")]
        public bool? ConfirmSegments { get; set; }
    }
}
