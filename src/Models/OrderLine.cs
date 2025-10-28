namespace BugStore.Models;

public class OrderLine
{
    public string Id { get; set; }
    public string OrderId { get; set; }
    
    public int Quantity { get; set; }
    public decimal Total { get; set; }
    
    public string ProductId { get; set; }
    public Product Product { get; set; }
}