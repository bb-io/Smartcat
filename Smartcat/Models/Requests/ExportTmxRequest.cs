using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Smartcat.DataSourceHandlers;
using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Smartcat.Models.Requests
{
    public class ExportTmxRequest
    {
        [Display("Translation Memory ID")]
        [DataSource(typeof(TMDataHandler))]
        public string TmId { get; set; }

        [Display("Export mode")]
        [StaticDataSource(typeof(ExportModeDataHandler))]
        public string ExportMode {  get; set; }

        [Display("With tags")]
        [StaticDataSource(typeof(YesNoDataHandler))]
        public bool WithTags {  get; set; }
    }
}
