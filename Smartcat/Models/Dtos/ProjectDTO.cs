using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Dtos;

public class ProjectDTO
{
    [Display("Project ID")]
    public string Id { get; set; }

    [Display("Account ID")]
    public string accountId { get; set; }

    [Display("Project name")]
    public string name { get; set; }

    [Display("Project description")]
    public string description { get; set; }

    [Display("Deadline")]
    public DateTime? deadline { get; set; }

    [Display("Creation date")]
    public DateTime creationDate { get; set; }

    [Display("Created by user ID")]
    public string createdByUserId { get; set; }

    [Display("Created by user email")]
    public string createdByUserEmail { get; set; }

    [Display("Modification date")]
    public DateTime? modificationDate { get; set; }

    [Display("Source language ID")]
    public int sourceLanguageId { get; set; }

    [Display("Source language")]
    public string sourceLanguage { get; set; }

    [Display("Target languages")]
    public List<string> targetLanguages { get; set; }

    [Display("Project status")]
    public string Status { get; set; }

    [Display("Status modification date")]
    public DateTime? statusModificationDate { get; set; }

    [Display("Client ID")]
    public string? clientId { get; set; }
}