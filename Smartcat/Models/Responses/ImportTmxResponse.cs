

using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Responses
{
    public class ImportTmxResponse
    {
        [Display("Status")]
        public string Status { get; set; }

        [Display("Message")]
        public string Message { get; set; }
    }
}
