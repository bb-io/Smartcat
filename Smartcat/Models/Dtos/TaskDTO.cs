using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Dtos;

public class TaskDTO
{
    [Display("Task Id")]
    public string Id { get; set; }
    public string number { get; set; }
    public string status { get; set; }
    public double progressPercentage { get; set; }

    [Display("Source Language")]
    public string sourceLanguage { get; set; }

    [Display("Target Language")]
    public string targetLanguage { get; set; }
    public string stageType { get; set; }
    public string stageId { get; set; }
    public DateTime deadline { get; set; }
    public double cost { get; set; }
    public double approximateCost { get; set; }
    public List<string> documentIds { get; set; }
    public DateTime createDate { get; set; }
    public DateTime lastUpdateScopeDate { get; set; }
    public List<IndividualAssignment> individualAssignments { get; set; }
    public List<VendorAssignment> vendorAssignments { get; set; }
    public string invitationStrategyType { get; set; }
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