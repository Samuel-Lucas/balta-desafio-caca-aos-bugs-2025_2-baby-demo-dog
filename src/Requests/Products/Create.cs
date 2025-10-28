using BugStore.Models;

namespace BugStore.Requests.Products;

public class Create
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Title { get; set; }
    public string Description { get; set; }
    public string Slug { get; set; }
    public decimal Price { get; set; }

    public Product ToEntity()
        => new Product
        {
            Id = Id,
            Title = Title,
            Description = Description,
            Slug = Slug,
            Price = Price
        };
}