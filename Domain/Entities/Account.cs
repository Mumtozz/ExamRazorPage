using Domain.Enums;

namespace Domain.Entities;

public class Account : BaseEntity
{
    
    public string? AccountNumber { get; set; }
    public decimal? Balance { get; set; }
    public int CustomerId { get; set; }
    public AccountType? Type { get; set; }
    public Customer? Customers { get; set; }
    public List<Transaction>? Transactions { get; set; }
}
