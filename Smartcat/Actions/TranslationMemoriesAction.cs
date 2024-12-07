using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Models.Requests;
using Apps.Smartcat.Models.Responses;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;

namespace Apps.Smartcat.Actions
{
    [ActionList]
    public class TranslationMemoriesAction : SmartcatInvocable
    {
        private readonly IFileManagementClient _fileManagementClient;

        public TranslationMemoriesAction(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
        {
            _fileManagementClient = fileManagementClient;
        }

        [Action("Import TMX to TM", Description = "Import a TMX file into translation memory")]
        public async Task<ImportTmxResponse> ImportTmxToTm(ImportTmxRequest input)
        {
            var fileStream = await _fileManagementClient.DownloadAsync(input.TmxFile);

            var url = $"{Urls.Api}translationmemory/{input.TmId}?replaceAllContent={input.ReplaceAllContent}";

            if (!string.IsNullOrEmpty(input.AssuranceLevel))
            {
                url += $"&assuranceLevel={input.AssuranceLevel}";
            }

            var request = new SmartcatRequest(url, Method.Post, Creds)
            {
                AlwaysMultipartFormData = true
            };

            request.AddFile("file", () => fileStream, input.TmxFile.Name);

            await Client.ExecuteWithHandling(request);

            return new ImportTmxResponse
            {
                Status = "Success",
                Message = "TMX file successfully imported into the translation memory."
            };
        }
    }
}
