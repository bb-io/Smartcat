using Apps.Smartcat.DataSourceHandlers.Static;
using Blackbird.Applications.Sdk.Common.Dictionaries;

namespace Apps.Smartcat.Webhooks.Models;

public class DocumentStatusChangedParameter
{
    [StaticDataSource(typeof(DocumentStatusDataHandler))]
    public string? Status { get; set; }
}