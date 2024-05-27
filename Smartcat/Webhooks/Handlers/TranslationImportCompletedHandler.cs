using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Smartcat.Webhooks.Handlers;

public class TranslationImportCompletedHandler : BaseSmartcatWebhookHandler
{
    protected override string Event => "/document/translationImportCompleted";

    public TranslationImportCompletedHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }
}