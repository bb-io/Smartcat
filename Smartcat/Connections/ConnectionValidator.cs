using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.Smartcat.Connections;

internal class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(IEnumerable<AuthenticationCredentialsProvider> authProviders, CancellationToken cancellationToken)
    {
        var client = new SmartcatClient();
        
        var request = new SmartcatRequest(Urls.Api + "project/list", Method.Get, authProviders);
        await client.ExecuteWithHandling(request);

        return new()
        {
            IsValid = true
        };
    }
}