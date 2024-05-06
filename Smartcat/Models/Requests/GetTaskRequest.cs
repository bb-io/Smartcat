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
    public class GetTaskRequest
    {
        [Display("Task ID")]
        [DataSource(typeof(TaskDataHandler))]
        public string ProjectTaskID { get; set; }

    }
}
