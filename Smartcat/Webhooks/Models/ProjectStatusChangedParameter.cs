using Apps.Smartcat.DataSourceHandlers;
using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dictionaries;
using Blackbird.Applications.Sdk.Common.Dynamic;

namespace Apps.Smartcat.Webhooks.Models;

public class ProjectStatusChangedParameter
{
    [Display("Project ID"), DataSource(typeof(ProjectDataHandler))]
    public string? ProjectId { get; set; }

    [StaticDataSource(typeof(ProjectStatusDataHandler))]
    public string? Status { get; set; }

    [Display("Client ID"), DataSource(typeof(ClientDataHandler))]
    public string? ClientId { get; set; }

    [Display("Account ID")] public string? AccountId { get; set; }
}