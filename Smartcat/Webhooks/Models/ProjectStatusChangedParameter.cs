using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.Webhooks.Models;

public class ProjectStatusChangedParameter
{
    [StaticDataSource(typeof(ProjectStatusDataHandler))]
    public string? Status { get; set; }
}