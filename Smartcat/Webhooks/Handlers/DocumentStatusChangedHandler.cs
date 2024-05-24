using Apps.Smartcat.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Smartcat.Webhooks.Handlers;

public class DocumentStatusChangedHandler : BaseSmartcatWebhookHandler
{
    protected override string Event => "/document/status";

    public DocumentStatusChangedHandler(InvocationContext invocationContext,
        [WebhookParameter] DocumentStatusChangedParameter input) : base(invocationContext)
    {
    }
}