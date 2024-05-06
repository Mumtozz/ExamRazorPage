using Domain.Enums;

namespace Domain.DTOs.AccountDTOs;

public class UpdateAccountDto
{
    public int Id { get; set; }
    public string? AccountNumber { get; set; } 
    public decimal? Balance { get; set; }
    public int CustomerId { get; set; }
    public AccountType Type { get; set; }
}
