using System.Text.RegularExpressions;
using Apps.Smartcat.Constants;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Smartcat.API;

public class SmartcatClient : RestClient
{
    private const string ErrorRegextPattern = @"(?<=\\r\\n)(.+)$";
    public SmartcatClient() : base(new RestClientOptions { BaseUrl = new(Urls.Api) })
    {
    }

    public async Task<T> ExecuteWithHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithHandling(request);

        return JsonConvert.DeserializeObject<T>(response.Content!)!;
    }

    public async Task<RestResponse> ExecuteWithHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);
        if (response.IsSuccessStatusCode)
            return response;

        if (response.StatusCode == System.Net.HttpStatusCode.Forbidden &&
                response.Content.Contains("Project tasks are not available for the requested"))
        {
            throw new PluginApplicationException("There are no available tasks for the selected project.");
        }

        var errorMessage = Regex.Match(response.Content.Trim('"'), ErrorRegextPattern).Groups[0].Value;
        throw new PluginApplicationException(string.IsNullOrWhiteSpace(errorMessage) ? response.Content : errorMessage);
    }
}