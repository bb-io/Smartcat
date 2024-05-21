using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Models.Dtos;
using Apps.Smartcat.Models.Requests;
using Apps.Smartcat.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;

namespace Apps.Smartcat.Actions;

[ActionList]
public class TaskActions : SmartcatInvocable
{
    private AuthenticationCredentialsProvider[] Creds =>
        InvocationContext.AuthenticationCredentialsProviders.ToArray();

    public TaskActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("List project tasks", Description = "List all project tasks")]
    public async Task<ListTasksResponse> ListAllTasks([ActionParameter] ListTasksRequest input)
    {
        var request = new SmartcatRequest(Urls.Api + $"/projectTask/{input.ProjectID}/list?currency={input.Currency}", Method.Get, Creds);
        var response = await Client.ExecuteWithHandling<List<TaskDTO>>(request);
        return new ListTasksResponse { Tasks = response };
            
    }

    [Action("Get task", Description = "Get specific project task")]
    public async Task<TaskDTO> GetTask([ActionParameter] ListTasksRequest listTasks, [ActionParameter] GetTaskRequest input)
    {
        var request = new SmartcatRequest(Urls.Api + $"projectTask/{listTasks.ProjectID}/{input.ProjectTaskID}?currency={listTasks.Currency}", Method.Get, Creds);
        return await Client.ExecuteWithHandling<TaskDTO>(request);
    }

}