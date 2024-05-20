using Apps.Smartcat.DataSourceHandlers;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Dynamic;
using Apps.Smartcat.Actions;
using Newtonsoft.Json;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Smartcat.Models.Requests
{
    
    public class UpdateProjectRequest
    {

        [DataSource(typeof(ProjectDataHandler))]
        [Display("Project ID")]
        public string ProjectId { get; set; }

        [Display("Project Name")]
        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? Deadline { get; set; }

        [Display("Client ID")]
        public string? ClientId { get; set; }

        [Display("External Tag")]
        public string? ExternalTag { get; set; }

        public string GetSerializedRequest(InvocationContext context)
        {
            if (Name is null)
            {
                Name = new ProjectActions(context).GetProject(new GetProjectRequest { Project = ProjectId}).Result.name;
            }
            return JsonConvert.SerializeObject(new
            {
                name = Name,
                description = Description,
                deadline = Deadline.HasValue? Deadline.Value.ToString("yyyy-MM-ddTHH:mm:ss.000Z") : null,
                clientId = ClientId,
                externalTag = ExternalTag
            }
            , new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

    }
}
