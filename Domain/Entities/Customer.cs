namespace Domain.Entities;

public class Customer : BaseEntity
{
    
    public string? CustomerName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? PhoneNumber { get; set; }
    public List<Account>? Accounts { get; set; }
}
