using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Models.Dtos;
using Apps.Smartcat.Models.Requests;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using RestSharp;

namespace Apps.Smartcat.Actions
{
    [ActionList]
    public class FileActions : SmartcatInvocable
    {
        private readonly IFileManagementClient _fileManagementClient;

        public FileActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
            invocationContext)
        {
            _fileManagementClient = fileManagementClient;
        }

        [Action("Upload file", Description = "Add file to project")]
        public async Task<string> UploadFile([ActionParameter] UploadFileRequest input)
        {
            var fileStream = await _fileManagementClient.DownloadAsync(input.File);
            var request = new SmartcatRequest(Urls.Api + $"project/document?projectId={input.ProjectID}", Method.Post, Creds);
            request.AlwaysMultipartFormData = true;
            request.AddFile("file", () => fileStream, input.File.Name);
            request.AddParameter("documentModel", $"[{input.GetSerializedRequest()}]");
            var response = await Client.ExecuteAsync(request);
            return response.Content;
        }

    }
}
