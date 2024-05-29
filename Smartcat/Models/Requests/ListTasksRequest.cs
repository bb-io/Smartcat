using Apps.Smartcat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Smartcat.Models.Requests;

public class ListTasksRequest
{
    [Display("Project ID")]
    [DataSource(typeof(ProjectDataHandler))]
    public string ProjectID { get; set; }

    [DataSource(typeof(CurrencyDataHandler))]
    public string Currency { get; set; }
}