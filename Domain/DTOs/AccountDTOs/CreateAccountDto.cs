using Domain.Enums;

namespace Domain.DTOs.AccountDTOs;

public class CreateAccountDto
{
     public string AccountNumber { get; set; } = null!;
    public decimal? Balance { get; set; }
    public int CustomerId { get; set; }
    public AccountType Type { get; set; }
}
