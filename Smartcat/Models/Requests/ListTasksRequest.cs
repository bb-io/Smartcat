using Apps.Smartcat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Smartcat.Models.Requests
{
    public class ListTasksRequest
    {
        [Display("Project ID")]
        public string ProjectID { get; set; }

        [DataSource(typeof(CurrencyDataHandler))]
        public string Currency { get; set; }
    }
}
