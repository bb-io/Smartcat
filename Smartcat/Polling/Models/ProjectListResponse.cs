using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;

namespace Apps.Smartcat.Polling.Models
{
    public class ProjectListResponse
    {
        [Display("Projects")]
        public List<ProjectResponse> Projects { get; set; }

        public ProjectListResponse(List<ProjectResponse> projects)
        {
            Projects = projects;
        }
    }
    public class ProjectResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("createdByUserEmail")]
        public string CreatedByUserEmail { get; set; }
    }
}
