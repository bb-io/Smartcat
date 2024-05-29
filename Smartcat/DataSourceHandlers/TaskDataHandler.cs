using Apps.Smartcat.Actions;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common;
using Apps.Smartcat.Models.Requests;

namespace Apps.Smartcat.DataSourceHandlers;

public class TaskDataHandler : BaseInvocable, IAsyncDataSourceHandler
{
    private ListTasksRequest ListTasksRequest { get; set; }

    private IEnumerable<AuthenticationCredentialsProvider> Creds =>
        InvocationContext.AuthenticationCredentialsProviders;

    public TaskDataHandler(InvocationContext invocationContext, [ActionParameter] ListTasksRequest listTasksRequest) : base(invocationContext)
    {
        ListTasksRequest = listTasksRequest;
    }

    public async Task<Dictionary<string, string>> GetDataAsync(DataSourceContext context,
        CancellationToken cancellationToken)
    {
        if (ListTasksRequest == null || string.IsNullOrEmpty(ListTasksRequest.ProjectID) || string.IsNullOrEmpty(ListTasksRequest.Currency))
        {
            throw new ArgumentException("Please, select the Project and Currency first");
        }
        var tasks = await new TaskActions(InvocationContext).ListAllTasks(new ListTasksRequest { ProjectID = ListTasksRequest.ProjectID, Currency = ListTasksRequest.Currency });
        if (tasks.Tasks.Any())
        {
            return tasks.Tasks
                .Where(x => context.SearchString == null ||
                            x.stageType.Contains(context.SearchString, StringComparison.OrdinalIgnoreCase))
                .Take(20)
                .ToDictionary(x => x.Id, x => x.stageType + " " + x.sourceLanguage + "  - " + x.targetLanguage);
        }
        else throw new Exception("There are no available tasks for the selected project");
    }
}