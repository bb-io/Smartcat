using Apps.Smartcat.DataSourceHandlers;
using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;

namespace Apps.Smartcat.Models.Requests;

public class UploadFileRequest
{
    [DataSource(typeof(ProjectDataHandler))]
    [Display("Project ID")]
    public string ProjectID { get; set; }
    public FileReference File { get; set; }
    
    [Display("External ID")]
    public string? ExternalId { get; set; }
    
    [Display("Meta info")]
    public string? MetaInfo { get; set; }
    
    [Display("Disassemble algorithm name")]
    public string? DisassembleAlgorithmName { get; set; }
    
    [Display("Preset disassemble algorithm")]
    public string? PresetDisassembleAlgorithm { get; set; }
    
    [Display("Target substitution mode")]
    [StaticDataSource(typeof(TargetSubstitutionModeStaticHandler))]
    public string? TargetSubstitutionMode { get; set; }
    
    [Display("Lock mode")]
    [StaticDataSource(typeof(LockModeStaticHandler))]
    public string? LockMode { get; set; }
    
    [Display("Confirm mode")]
    [StaticDataSource(typeof(ConfirmModeStaticHandler))]
    public string? ConfirmMode { get; set; }
    
    [Display("Target languages")]
    [StaticDataSource(typeof(LanguageDataHandler))]
    public List<string>? TargetLanguages { get; set; }
    
    [Display("Enable placeholders")]
    public bool? EnablePlaceholders { get; set; }
    
    [Display("Enable OCR")]
    public bool? EnableOcr { get; set; }

    public string GetSerializedRequest()
    {
        return JsonConvert.SerializeObject(new 
            {
                externalId = ExternalId,
                metaInfo = MetaInfo,
                disassembleAlgorithmName = DisassembleAlgorithmName,
                presetDisassembleAlgorithm = PresetDisassembleAlgorithm,
                bilingualFileImportSetings = new {
                    targetSubstitutionMode = TargetSubstitutionMode,
                    lockMode = LockMode,
                    confirmMode = ConfirmMode
                },                
                targetLanguages = TargetLanguages?.Select(t => t).ToArray(),
                enablePlaceholders = EnablePlaceholders,
                enableOcr = EnableOcr
            }
            , new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
    }
}