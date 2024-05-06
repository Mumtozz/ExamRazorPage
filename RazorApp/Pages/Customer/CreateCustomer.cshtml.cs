using Domain.DTOs.CustomerDTOs;
using Infrastructure.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Customer
{
    [IgnoreAntiforgeryToken]
    public class CreateCustomerModel : PageModel
    {
        private readonly ICustomerService _CustomerService;

        public CreateCustomerModel(ICustomerService CustomerService)
        {
            _CustomerService = CustomerService;
        }

        [BindProperty] public CreateCustomerDto CustomerDto { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _CustomerService.CreateCustomerAsync(CustomerDto);

            return RedirectToPage("/Customer/GetCustomers");
        }
    }
}