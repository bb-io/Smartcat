using Apps.Smartcat.Models.Dtos;

namespace Apps.Smartcat.Models.Responses;

public class ListProjectsResponse
{
    public IEnumerable<ProjectDTO> Projects { get; set; }
}