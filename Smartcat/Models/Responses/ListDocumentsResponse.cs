using Apps.Smartcat.Models.Dtos;

namespace Apps.Smartcat.Models.Responses;

public class ListDocumentsResponse
{
    public IEnumerable<DocumentDto> Documents { get; set; }
}