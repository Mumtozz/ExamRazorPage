namespace Domain.DTOs.TransactionDTOs;

public class UpdateTransactionDto
{
    public int Id { get; set; }
    public int FromAccountId { get; set; }
    public int ToAccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
}
