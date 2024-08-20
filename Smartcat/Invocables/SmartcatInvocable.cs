using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using Apps.Smartcat.API;

namespace Apps.Smartcat.Invocables;

public class SmartcatInvocable : BaseInvocable
{
    protected AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    protected SmartcatClient Client { get; }

    public SmartcatInvocable(InvocationContext invocationContext) : base(invocationContext)
    {
        Client = new();
    }
}