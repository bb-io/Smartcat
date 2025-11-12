using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using Apps.Smartcat.Models.Dtos;
using Apps.Smartcat.Models.Responses;
using Apps.Smartcat.Models.Requests;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.API;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Apps.Smartcat.Actions;

[ActionList("Projects")]
public class ProjectActions : SmartcatInvocable
{
    private AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    public ProjectActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List projects", Description = "List all projects in account")]
    public async Task<ListProjectsResponse> ListAllProjects()
    {
        var request = new SmartcatRequest(Urls.Api + "project/list", Method.Get, Creds);
        var response = await Client.ExecuteWithHandling<List<FullProjectDTO>>(request);
        var projectsResponse = new ListProjectsResponse { Projects = response };
        return projectsResponse;
    }

    [Action("Get project", Description = "Get specific project")]
    public async Task<FullProjectDTO> GetProject([ActionParameter] GetProjectRequest input)
    {
        var request = new SmartcatRequest(Urls.Api + "project/" + input.Project, Method.Get, Creds);
        return await Client.ExecuteWithHandling<FullProjectDTO>(request);
    }

    [Action("List files in a project", Description = "List files in a project")]
    public async Task<List<DocumentDto>> ListFilesInProject([ActionParameter] GetProjectRequest input)
    {
        var request = new SmartcatRequest(Urls.Api + "project/" + input.Project, Method.Get, Creds);
        var response = await Client.ExecuteAsync(request);
        var token = JObject.Parse(response.Content).SelectToken("documents");
        return token?.ToObject<List<DocumentDto>>() ?? new List<DocumentDto>();
    }

    [Action("Update project", Description = "Update project info")]
    public async Task<FullProjectDTO> UpdateProject([ActionParameter] UpdateProjectRequest input)
    {
        var request = new SmartcatRequest(Urls.Api + "project/" + input.ProjectId, Method.Put, Creds);
        request.AddStringBody(input.GetSerializedRequest(InvocationContext), DataFormat.Json);
        await Client.ExecuteWithHandling(request);
        return await GetProject(new GetProjectRequest { Project = input.ProjectId });
    }

    [Action("Create project", Description = "Create a new project")]
    public async Task<ProjectDto> CreateProject([ActionParameter] CreateProjectRequest input)
    {
        var create = new SmartcatRequest(Urls.Api + "project/create", Method.Post, Creds)
        {
            AlwaysMultipartFormData = true
        };
        create.AddParameter("projectModel", input.GetSerializedRequest());

        var project = await Client.ExecuteWithHandling<ProjectDto>(create);

        if (input.TranslationMemoryIds is { } tmIds && tmIds.Any())
        {
            var tmModels = tmIds.Select(id => new
            {
                id,
                isWritable = true,
                matchThreshold = 100
            }).ToArray();

            var setTmsReq = new SmartcatRequest(
                Urls.Api + $"project/{project.Id}/translationmemories",
                Method.Post, Creds);

            setTmsReq.AddJsonBody(tmModels);
            await Client.ExecuteWithHandling<object>(setTmsReq);
        }

        return project;
    }

    [Action("Delete project", Description = "Delete a specific project")]
    public async Task DeleteProject([ActionParameter] GetProjectRequest input)
    {
        var request = new SmartcatRequest(Urls.Api + $"project/{input.Project}", Method.Delete, Creds);
        
        await Client.ExecuteAsync(request);

        return;
    }

    [Action("Complete workflow for all documents", Description = "Completes the workflow for all project documents, changing the project status to Completed")]
    public async Task CompleteWorkflowForDocumentsProject([ActionParameter] GetProjectRequest input)
    {
        var request = new SmartcatRequest($"{Urls.Api}project/complete?projectId={input.Project}", Method.Post, Creds);
        await Client.ExecuteWithHandling(request);
        return;
    }

    [Action("Set document as completed", Description = "Change the document status to Completed")]
    public async Task SetDocumentAsCompleted([ActionParameter] CompleteDocumentRequest input)
    {
        var request = new SmartcatRequest($"{Urls.Api}document/complete?documentId={input.DocumentId}",Method.Post,Creds);
        await Client.ExecuteWithHandling(request);
        return;
    }


    [Action("Get project statistics", Description = "Get statistics for the specified project")]
    public async Task<ProjectStatisticsResponse> GetProjectStatistics([ActionParameter] ProjectStatisticsRequest input)
    {
        var request = new SmartcatRequest($"https://smartcat.ai/api/integration/v2/project/{input.Project}/statistics", Method.Delete, Creds);
        request.AddQueryParameter("onlyExactMatches", $"{input.onlyExactMatches ?? false}");
        var response = await Client.ExecuteWithHandling<List<LanguageStatisticsDTO>>(request);

        return new ProjectStatisticsResponse(response);
    }
}