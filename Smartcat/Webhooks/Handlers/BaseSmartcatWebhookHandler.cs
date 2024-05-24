using System.Text;
using Apps.Smartcat.API;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Utils.Extensions.Http;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge;
using Blackbird.Applications.Sdk.Utils.Webhooks.Bridge.Models.Request;
using RestSharp;

namespace Apps.Smartcat.Webhooks.Handlers;

public abstract class BaseSmartcatWebhookHandler : InvocableBridgeWebhookHandler
{
    protected abstract string Event { get; }

    private const string EventTypeQuery = "eventType";
    private const string IdQuery = "id";

    public BaseSmartcatWebhookHandler(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    public override async Task SubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
        Dictionary<string, string> values)
    {
        var endpoint =
            $"{InvocationContext.UriInfo.BridgeServiceUrl}/webhooks/smartcat"
                .SetQueryParameter(IdQuery, authenticationCredentialsProvider.Get("userName").Value)
                .SetQueryParameter(EventTypeQuery, string.Empty);
        var request = new SmartcatRequest("callback", Method.Post, authenticationCredentialsProvider)
            .WithJsonBody(new
            {
                url = endpoint
            });

        await new SmartcatClient().ExecuteWithHandling(request);
        await base.SubscribeAsync(authenticationCredentialsProvider, values);
    }

    public override async Task UnsubscribeAsync(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
        Dictionary<string, string> values)
    {
        var request = new SmartcatRequest("callback", Method.Delete, authenticationCredentialsProvider);

        await new SmartcatClient().ExecuteWithHandling(request);
        await base.UnsubscribeAsync(authenticationCredentialsProvider, values);
    }

    protected override Task<(BridgeRequest webhookData, BridgeCredentials bridgeCreds)> GetBridgeServiceInputs(
        Dictionary<string, string> values, IEnumerable<AuthenticationCredentialsProvider> creds)
    {
        var eventBytes = Encoding.UTF8.GetBytes(Event);
        var webhookData = new BridgeRequest
        {
            Event = Convert.ToBase64String(eventBytes),
            Id = creds.Get("userName").Value,
            Url = values["payloadUrl"],
        };

        var bridgeCreds = new BridgeCredentials
        {
            ServiceUrl = $"{InvocationContext.UriInfo.BridgeServiceUrl}/webhooks/smartcat",
            Token = ApplicationConstants.BlackbirdToken
        };

        return Task.FromResult((webhookData, bridgeCreds));
    }
}