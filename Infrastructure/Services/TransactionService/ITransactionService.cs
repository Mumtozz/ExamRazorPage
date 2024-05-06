using Domain.DTOs.TransactionDTOs;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.TransactionService;

public interface ITransactionService
{
     Task<PagedResponse<List<GetTransactionDto>>> GetTransactionsAsync(PaginationFilter filter);
    Task<Response<GetTransactionDto>> GetTransactionByIdAsync(int transactionId);
    Task<Response<string>> CreateTransactionAsync(CreateTransactionDto transaction);
    Task<Response<string>> UpdateTransactionAsync(UpdateTransactionDto transaction);
    Task<Response<bool>> RemoveTransactionAsync(int transactionId);
}
