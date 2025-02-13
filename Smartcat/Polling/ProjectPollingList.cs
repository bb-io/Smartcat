using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Polling.Models;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;

namespace Apps.Smartcat.Polling
{
    [PollingEventList]
    public class ProjectPollingList : SmartcatInvocable
    {
        public ProjectPollingList(InvocationContext invocationContext):base(invocationContext) { }

        [PollingEvent("On project created", "Triggered when a new project was created")]
        public async Task<PollingEventResponse<ProjectMemory, ProjectListResponse>> OnProjectCreated(
            PollingEventRequest<ProjectMemory> request, 
            [PollingEventParameter][Display("Project name contains")] string? projectNameContains)
        {
            if(request.Memory is null)
        {
                return new()
                {
                    FlyBird = false,
                    Memory = new()
                    {
                        LastPollingTime = DateTime.UtcNow,
                        Triggered = false
                    }
                };
            }

            var getProjectRequest = new SmartcatRequest(Urls.Api + "project/list", RestSharp.Method.Get, Creds);
            var response = await Client.ExecuteWithHandling<List<ProjectResponse>>(getProjectRequest);

            var newProjects = response
                .Where(p => p.CreationDate > request.Memory.LastPollingTime).OrderByDescending(p => p.CreationDate).ToList();

            if (newProjects.Any())
            {

                if (!String.IsNullOrEmpty(projectNameContains))
                {
                    if (newProjects.Any(x => x.Name.Contains(projectNameContains)))
                    {
                        return new()
                        {
                            FlyBird = true,
                            Memory = new ProjectMemory
                            {
                                LastPollingTime = DateTime.UtcNow,
                                Triggered = true
                            },
                            Result = new ProjectListResponse
                            {
                                Projects = newProjects.Where(x => x.Name.Contains(projectNameContains)).ToList()
                            }
                        };
                    }
                    else
                    {
                        return new()
                        {
                            FlyBird = false,
                            Memory = new ProjectMemory
                            {
                                LastPollingTime = DateTime.UtcNow,
                                Triggered = false
                            }
                        };
                    }
                }

                return new()
                {
                    FlyBird = true,
                    Memory = new ProjectMemory
                    {
                        LastPollingTime = DateTime.UtcNow,
                        Triggered = true
                    },
                    Result = new ProjectListResponse
                    {
                        Projects = newProjects
                    }
                };
            }

            return new()
            {
                FlyBird = false,
                Memory = new ProjectMemory
                {
                    LastPollingTime = DateTime.UtcNow,
                    Triggered = false
                }
            };
        }
            
    }
}
