

using Apps.Smartcat.DataSourceHandlers;
using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Smartcat.Models.Requests
{
    public class ImportTmxRequest
    {
        [Display("Translation Memory ID")]
        [DataSource(typeof(TMDataHandler))]
        public string TmId { get; set; }

        [Display("Replace all content")]
        [StaticDataSource(typeof(YesNoDataHandler))]
        public bool ReplaceAllContent { get; set; }

        [Display("Assurance level")]
        public string? AssuranceLevel { get; set; }

        [Display("TMX file")]
        public FileReference TmxFile { get; set; }
    }
}
