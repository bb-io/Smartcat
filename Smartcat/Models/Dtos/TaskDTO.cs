using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Dtos;

public class TaskDTO
{
    [Display("Task ID")]
    public string Id { get; set; }

    [Display("Task number")]
    public string number { get; set; }

    [Display("Task status")]
    public string status { get; set; }

    [Display("Progress percentage")]
    public double progressPercentage { get; set; }

    [Display("Source language")]
    public string sourceLanguage { get; set; }

    [Display("Target language")]
    public string targetLanguage { get; set; }

    [Display("Stage type")]
    public string stageType { get; set; }

    [Display("Deadline")]
    public DateTime? deadline { get; set; }

    [Display("Cost")]
    public double cost { get; set; }

    [Display("Approximate cost")]
    public double approximateCost { get; set; }

    [Display("Document IDs")]
    public List<string> documentIds { get; set; }

    [Display("Creation date")]
    public DateTime createDate { get; set; }
    //public DateTime lastUpdateScopeDate { get; set; }
    //public List<IndividualAssignment> individualAssignments { get; set; }
    //public List<VendorAssignment> vendorAssignments { get; set; }
    //public string invitationStrategyType { get; set; }
}
public class VendorAssignment
{
    public string accountId { get; set; }
    public string name { get; set; }
    public bool canUnassign { get; set; }
    public double rate { get; set; }
    public string status { get; set; }
}

public class IndividualAssignment
{
    public string userId { get; set; }
    public double rate { get; set; }
    public string currency { get; set; }
    public string status { get; set; }
}