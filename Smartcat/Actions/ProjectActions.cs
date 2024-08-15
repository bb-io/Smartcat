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

namespace Apps.Smartcat.Actions;

[ActionList]
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
        var request = new SmartcatRequest(Urls.Api + "project/create", Method.Post, Creds);
        request.AlwaysMultipartFormData = true;
        request.AddParameter("projectModel", input.GetSerializedRequest());
        return await Client.ExecuteWithHandling<ProjectDto>(request);
    }

    [Action("Delete project", Description = "Delete a specific project")]
    public async Task DeleteProject([ActionParameter] GetProjectRequest input)
    {
        var request = new SmartcatRequest(Urls.Api + $"project/{input.Project}", Method.Delete, Creds);
        
        await Client.ExecuteAsync(request);

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