using Domain.DTOs.AccountDTOs;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services;

public interface IAccountService
{
    
    Task<PagedResponse<List<GetAccountDto>>> GetAccountsAsync(AccountFilter filter);
    Task<Response<GetAccountDto>> GetAccountByIdAsync(int AccountId);
    Task<Response<string>> CreateAccountAsync(CreateAccountDto Account);
    Task<Response<string>> UpdateAccountAsync(UpdateAccountDto Account);
    Task<Response<bool>> RemoveAccountAsync(int AccountId);
}
