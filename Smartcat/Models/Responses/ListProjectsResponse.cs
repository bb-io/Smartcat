using Apps.Smartcat.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apps.Smartcat.Models.Responses
{
    public class ListProjectsResponse
    {
        public IEnumerable<ProjectDTO> Projects { get; set; }
    }
}
