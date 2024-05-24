using Apps.Smartcat.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Smartcat.Webhooks.Handlers;

public class ProjectStatusChangedHandler : BaseSmartcatWebhookHandler
{
    protected override string Event => "/project/status";

    public ProjectStatusChangedHandler(InvocationContext invocationContext,
        [WebhookParameter] ProjectStatusChangedParameter input) : base(invocationContext)
    {
    }
}