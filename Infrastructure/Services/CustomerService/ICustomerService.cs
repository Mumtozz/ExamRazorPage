using Domain.DTOs.CustomerDTOs;
using Domain.Filters;
using Domain.Responses;

namespace Infrastructure.Services.CustomerService;

public interface ICustomerService
{
    
    Task<PagedResponse<List<GetCustomerDto>>> GetCustomersAsync(CustomerFilter filter);
    Task<Response<GetCustomerDto>> GetCustomerByIdAsync(int customerId);
    Task<Response<string>> CreateCustomerAsync(CreateCustomerDto customer);
    Task<Response<string>> UpdateCustomerAsync(UpdateCustomerDto customer);
    Task<Response<bool>> RemoveCustomerAsync(int customerId);
}
