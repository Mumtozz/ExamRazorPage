using Domain.DTOs.TransactionDTOs;
using Infrastructure.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Transaction
{
    public class UpdateTransactionModel : PageModel
    {
        private readonly ITransactionService _TransactionService;

        public UpdateTransactionModel(ITransactionService TransactionService)
        {
            _TransactionService = TransactionService;
        }

        [BindProperty]
        public UpdateTransactionDto Transaction { get; set; }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            
            Transaction.Id = id; 
            await _TransactionService.UpdateTransactionAsync(Transaction);

            return RedirectToPage("/Transaction/GetTransactions");
        }
    }
}