using Apps.Smartcat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Smartcat.Models.Requests;

public class GetProjectRequest
{
    [DataSource(typeof(ProjectDataHandler))]
    public string Project { get; set; }
}