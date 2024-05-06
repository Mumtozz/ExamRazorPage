namespace Domain.DTOs.TransactionDTOs;

public class CreateTransactionDto
{
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime? TransactionDate { get; set; }
}
