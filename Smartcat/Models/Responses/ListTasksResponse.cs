using Apps.Smartcat.Models.Dtos;

namespace Apps.Smartcat.Models.Responses
{
    public class ListTasksResponse
    {
        public IEnumerable<TaskDTO> Tasks { get; set; }
    }
}
