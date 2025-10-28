using System.Text.Json.Serialization;
using BugStore.Models;

namespace BugStore.Requests.Customers;

public class Create
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? BirthDate { get; set; }

    public Customer ToEntity()
        => new Customer
        {
            Id = Id,
            Name = Name,
            Email = Email,
            Phone = Phone,
            BirthDate = BirthDate!
        };
}