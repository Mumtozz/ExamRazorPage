using Domain.DTOs.AccountDTOs;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Account
{
    [IgnoreAntiforgeryToken]
    public class CreateAccountModel : PageModel
    {
        private readonly IAccountService _AccountService;

        public CreateAccountModel(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }

        [BindProperty] public CreateAccountDto AccountDto { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _AccountService.CreateAccountAsync(AccountDto);

            return RedirectToPage("/Account/GetAccounts");
        }
    }
}