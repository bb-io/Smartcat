using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Models.Dtos;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Smartcat.DataSourceHandlers
{
    public class TMDataHandler : SmartcatInvocable, IAsyncDataSourceHandler
    {
        private IEnumerable<AuthenticationCredentialsProvider> Creds =>
           InvocationContext.AuthenticationCredentialsProviders;

        public TMDataHandler(InvocationContext invocationContext) : base(invocationContext)
        {
        }

        public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
    CancellationToken cancellationToken)
        {
            var queryParameters = new Dictionary<string, string>
            {
                 { "batchSize", "20" }
            };

            if (!string.IsNullOrEmpty(context.SearchString))
                queryParameters.Add("searchName", context.SearchString);

            var queryString = string.Join("&", queryParameters.Select(p => $"{p.Key}={p.Value}"));
            var url = $"{Urls.Api}translationmemory?{queryString}";

            var request = new SmartcatRequest(url, Method.Get, Creds);

            var tms = await Client.ExecuteWithHandling<List<Item>>(request);

            return tms.ToDictionary(x => x.id, x => x.name);
        }
    }
}
