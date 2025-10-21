using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Models.Requests;
using Apps.Smartcat.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;

namespace Apps.Smartcat.Actions
{
    [ActionList("Translation memory")]
    public class TranslationMemoriesAction : SmartcatInvocable
    {
        private readonly IFileManagementClient _fileManagementClient;

        public TranslationMemoriesAction(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
        {
            _fileManagementClient = fileManagementClient;
        }

        [Action("Import TMX to TM", Description = "Import a TMX file into translation memory")]
        public async Task<ImportTmxResponse> ImportTmxToTm([ActionParameter]ImportTmxRequest input)
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


        [Action("Export TMX from TM", Description = "Export a TMX from translation memory")]
        public async Task<FileResponse> ExportTmxFromTm([ActionParameter] ExportTmxRequest input)
        {
            var url = $"{Urls.Api}translationmemory/{input.TmId}/file?exportMode={input.ExportMode}&withTags={input.WithTags.ToString()}";

            var request = new SmartcatRequest(url,Method.Get,Creds);
            var response = await Client.ExecuteWithHandling(request);
            if (!response.IsSuccessful || response.RawBytes ==null)
            {
                throw new Exception($"Error exception TMX file: {response.StatusCode} -{response.Content}- {response.ErrorMessage}");
            }

            var filename = Regex.Match(
         response.ContentHeaders?.FirstOrDefault(x => x.Name == "Content-Disposition")?.Value.ToString() ?? "",
         "filename=\"?(.*?)\"?;"
     ).Groups[1].Value;

            if (string.IsNullOrEmpty(filename))
                throw new Exception("Failed to retrieve file name from server response.");

            var file = await _fileManagementClient.UploadAsync(
        new MemoryStream(response.RawBytes),
        response.ContentType ?? "application/octet-stream",
        filename
    );

            return new FileResponse
            {
                File = file
            };
        }
    }
}
