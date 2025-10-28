using System.ComponentModel.DataAnnotations;

namespace BugStore.Models;

public class Customer {
    [Key]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? BirthDate { get; set; }
}