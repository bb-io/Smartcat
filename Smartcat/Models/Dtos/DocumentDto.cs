using Blackbird.Applications.Sdk.Common;

namespace Apps.Smartcat.Models.Dtos;

public class DocumentDto
{
    [Display("Document ID")]
    public string Id { get; set; }
    
    public string Name { get; set; }
    
    [Display("Full path")]
    public string FullPath { get; set; }
    
    [Display("Source language")]
    public string SourceLanguage { get; set; }
    
    [Display("Target language")]
    public string TargetLanguage { get; set; }
    
    [Display("Project ID")]
    public string ProjectId { get; set; }
    
    public string Status { get; set; }
}