namespace BugStore.Requests.Customers;

public class Update
{
    public string Name { get; set; }
    public string Phone { get; set; }
    public string? BirthDate { get; set; }
}