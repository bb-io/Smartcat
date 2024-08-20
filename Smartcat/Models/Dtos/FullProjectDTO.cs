using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Dtos;

public class FullProjectDTO : ProjectDto
{
    [Display("Deadline")]
    public DateTime? deadline { get; set; }
}