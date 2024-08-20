using Blackbird.Applications.Sdk.Common.Authentication;
using RestSharp;

namespace Apps.Smartcat.API;

public class SmartcatRequest : RestRequest
{
    public SmartcatRequest(
        string resource,
        Method method,
        IEnumerable<AuthenticationCredentialsProvider> creds) : base(resource, method)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(creds.First(x => x.KeyName == "userName").Value + ":" + creds.First(x => x.KeyName == "password").Value);
        string val = Convert.ToBase64String(plainTextBytes);
        this.AddHeader("Authorization", "Basic " + val);
    }
}