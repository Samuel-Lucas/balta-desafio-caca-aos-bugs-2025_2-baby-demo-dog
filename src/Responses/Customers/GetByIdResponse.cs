namespace BugStore.Responses.Customers;

public class GetByIdResponse
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string? BirthDate { get; set; }
}