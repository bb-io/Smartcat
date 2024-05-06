using Apps.Smartcat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Smartcat.Models.Requests
{
    public class GetProjectRequest
    {
        [DataSource(typeof(ProjectDataHandler))]
        public string Project { get; set; }
    }
}
