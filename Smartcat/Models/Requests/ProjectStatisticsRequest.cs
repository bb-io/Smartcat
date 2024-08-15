using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Requests
{
    public class ProjectStatisticsRequest : GetProjectRequest
    {
        [Display("Include exact matched only", Description = "Default is false")]
        public bool? onlyExactMatches { get; set; }
    }
}
