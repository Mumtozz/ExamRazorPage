using System.Net;
using Domain.DTOs.CustomerDTOs;
using Domain.Filters;
using Infrastructure.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Customer
{
    public class GetCustomersModel : PageModel
    {
        private readonly ICustomerService _CustomerService;

        public GetCustomersModel(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [BindProperty(SupportsGet = true)]
        public CustomerFilter Filter { get; set; }

        public List<GetCustomerDto> Customers { get; set; }
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var response = await _CustomerService.GetCustomersAsync(Filter);
                Customers = response.Data;
                TotalPages = response.TotalPages;
                return Page();
            }
            catch (Exception)
            {
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}