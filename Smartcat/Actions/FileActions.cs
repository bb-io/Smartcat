﻿using System.Net;
using System.Net.Mime;
using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Models.Requests;
using Apps.Smartcat.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using RestSharp;

namespace Apps.Smartcat.Actions;

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
    public async Task UploadFile([ActionParameter] UploadFileRequest input)
    {
        var fileStream = await _fileManagementClient.DownloadAsync(input.File);
        var request = new SmartcatRequest(Urls.Api + $"project/document?projectId={input.ProjectID}", Method.Post,
            Creds);
        request.AlwaysMultipartFormData = true;
        request.AddFile("file", () => fileStream, input.File.Name);
        request.AddParameter("documentModel", $"[{input.GetSerializedRequest()}]");
        await Client.ExecuteAsync(request);
    }

    [Action("Download file", Description = "Download specific project file")]
    public async Task<FileResponse> DownloadFile([ActionParameter] DocumentRequest document,
        [ActionParameter] DownloadFileRequest input)
    {
        var exportTask = await GetExportTask(document, input);

        var endpoint = $"document/export/{exportTask.Id}";
        var request = new SmartcatRequest(endpoint, Method.Get, Creds);

        RestResponse response;
        do
        {
            await Task.Delay(2000);
            response = await Client.ExecuteWithHandling(request);
        } while (response.StatusCode == HttpStatusCode.NoContent);

        return new()
        {
            File = await _fileManagementClient.UploadAsync(new MemoryStream(response.RawBytes),
                response.ContentType ?? MediaTypeNames.Application.Octet,
                $"{document.DocumentId}_{document.LanguageID}")
        };
    }

    private Task<ExportTaskResponse> GetExportTask(DocumentRequest document, DownloadFileRequest input)
    {
        var endpoints = $"document/export?documentIds={document.DocumentId}_{document.LanguageID}".WithQuery(input);
        var request = new SmartcatRequest(endpoints, Method.Post, Creds);

        return Client.ExecuteWithHandling<ExportTaskResponse>(request);
    }
}