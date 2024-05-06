using Blackbird.Applications.Sdk.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Smartcat.Models.Dtos
{
    public class ProjectDTO
    {
        [Display("Project Id")]
        public string Id { get; set; }

        [Display("Account Id")]
        public string accountId { get; set; }

        [Display("Project Name")]
        public string name { get; set; }

        [Display("Project Description")]
        public string description { get; set; }

        [Display("Deadline")]
        public DateTime deadline { get; set; }

        [Display("Creation Date")]
        public DateTime creationDate { get; set; }

        [Display("Created By User Id")]
        public string createdByUserId { get; set; }

        [Display("Created By User Email")]
        public string createdByUserEmail { get; set; }

        [Display("Modification Date")]
        public DateTime? modificationDate { get; set; }

        [Display("Source Language Id")]
        public int sourceLanguageId { get; set; }

        [Display("Source Language")]
        public string sourceLanguage { get; set; }

        [Display("Target Languages")]
        public List<string> targetLanguages { get; set; }

        [Display("Project Status")]
        public string status { get; set; }

        [Display("Status Modification Date")]
        public DateTime statusModificationDate { get; set; }

        [Display("Client Id")]
        public string? clientId { get; set; }
    }
}
