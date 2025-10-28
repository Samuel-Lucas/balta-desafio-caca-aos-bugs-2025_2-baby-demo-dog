using BugStore.Models;

namespace BugStore.Requests.Orders;

public class Create
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string CustomerId { get; set; }
    public Customer Customer { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; }

    public Order ToEntity()
        => new Order
        {
            Id = Id,
            CustomerId = CustomerId,
            CreatedAt = CreatedAt,
            UpdatedAt = UpdatedAt
        };
}