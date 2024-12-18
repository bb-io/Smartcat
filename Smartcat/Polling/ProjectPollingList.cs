using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Apps.Smartcat.API;
using Apps.Smartcat.Constants;
using Apps.Smartcat.Invocables;
using Apps.Smartcat.Polling.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;

namespace Apps.Smartcat.Polling
{
    [PollingEventList]
    public class ProjectPollingList : SmartcatInvocable
    {
        public ProjectPollingList(InvocationContext invocationContext):base(invocationContext) { }

        [PollingEvent("On project created", "Triggered when a new project was created")]
        public async Task<PollingEventResponse<ProjectMemory, ProjectResponse>> OnProjectCreated(
            PollingEventRequest<ProjectMemory> request)
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

            var newProjects = response.Where(p => p.CreationDate > request.Memory.LastPollingTime).ToList();

            if (newProjects.Any())
            {
                return new()
                {
                    FlyBird = true,
                    Memory = new ProjectMemory
                    {
                        LastPollingTime = DateTime.UtcNow,
                        Triggered = true
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
