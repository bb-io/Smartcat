using Apps.Smartcat.Models.Dtos;

namespace Apps.Smartcat.Models.Responses;

public class ListProjectsResponse
{
    public IEnumerable<FullProjectDTO> Projects { get; set; }
}