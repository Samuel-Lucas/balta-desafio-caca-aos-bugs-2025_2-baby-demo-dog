namespace BugStore.Responses.Orders;

public class GetByIdResponse
{
    public string Id { get; set; }
    public string CustomerId { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}