using Apps.Smartcat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;
using Newtonsoft.Json;

namespace Apps.Smartcat.Models.Requests
{
    public class UploadFileRequest
    {
        [DataSource(typeof(ProjectDataHandler))]
        [Display("Project ID")]
        public string ProjectID { get; set; }
        public FileReference File { get; set; }
        public string? ExternalId { get; set; }
        public string? MetaInfo { get; set; }
        public string? DisassembleAlgorithmName { get; set; }
        public string? PresetDisassembleAlgorithm { get; set; }
        public string? TargetSubstitutionMode { get; set; }
        public string? LockMode { get; set; }
        public string? ConfirmMode { get; set; }
        public List<string>? TargetLanguages { get; set; }
        public bool? EnablePlaceholders { get; set; }
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
}
