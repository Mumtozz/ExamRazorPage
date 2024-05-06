using Domain.DTOs.TransactionDTOs;
using Infrastructure.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Transaction
{
    [IgnoreAntiforgeryToken]
    public class CreateTransactionModel : PageModel
    {
        private readonly ITransactionService _TransactionService;

        public CreateTransactionModel(ITransactionService TransactionService)
        {
            _TransactionService = TransactionService;
        }

        [BindProperty] public CreateTransactionDto TransactionDto { get; set; }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _TransactionService.CreateTransactionAsync(TransactionDto);

            return RedirectToPage("/Transaction/GetTransactions");
        }
    }
}