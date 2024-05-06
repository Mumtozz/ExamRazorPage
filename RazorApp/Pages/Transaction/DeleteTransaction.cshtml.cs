using Infrastructure.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Transaction
{
    public class DeleteTransactionModel : PageModel
    {
        private readonly ITransactionService _TransactionService;

        public DeleteTransactionModel(ITransactionService TransactionService)
        {
            _TransactionService = TransactionService;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            await _TransactionService.RemoveTransactionAsync(Id);
            return RedirectToPage("/Transaction/GetTransactions");
        }
    }
}