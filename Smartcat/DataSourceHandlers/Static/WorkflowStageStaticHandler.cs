using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.DataSourceHandlers.Static;

public class WorkflowStageStaticHandler : IStaticDataSourceHandler
{
    public Dictionary<string, string> GetData()
    {
        return new()
        {
            ["Translation"] = "Translation",
            ["Editing"] = "Editing",
            ["Proofreading"] = "Proofreading",
            ["Postediting"] = "Postediting",
            ["FinalPageProof"] = "FinalPageProof",
            ["Notarization"] = "Notarization",
            ["CertifiedTranslation"] = "CertifiedTranslation",
            ["Transcreation"] = "Transcreation",
            ["Legalization"] = "Legalization",
            ["PreliminaryPageProof"] = "PreliminaryPageProof",
            ["LQAReview"] = "LQAReview"
        };
    }
}