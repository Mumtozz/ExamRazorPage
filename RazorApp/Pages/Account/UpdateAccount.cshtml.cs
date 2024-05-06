using Domain.DTOs.AccountDTOs;
using Infrastructure.Services;
using Infrastructure.Services.AccountService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Account
{
    public class UpdateAccountModel : PageModel
    {
        private readonly IAccountService _AccountService;

        public UpdateAccountModel(IAccountService AccountService)
        {
            _AccountService = AccountService;
        }

        [BindProperty]
        public UpdateAccountDto Account { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            Account.Id = id; 
            await _AccountService.UpdateAccountAsync(Account);

            return RedirectToPage("/Account/GetAccounts");
        }
    }
}