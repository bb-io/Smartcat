using Apps.Smartcat.Constants;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Smartcat.API;

public class SmartcatClient : RestClient
{
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
            throw new("There are no available tasks for the selected project.");
        }

        throw new(response.Content);
    }
}