using System.Net;
using Domain.DTOs.TransactionDTOs;
using Domain.Filters;
using Infrastructure.Services.TransactionService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Transaction
{
    public class GetTransactionModel : PageModel
    {
        private readonly ITransactionService _TransactionService;

        public GetTransactionModel(ITransactionService TransactionService)
        {
            _TransactionService = TransactionService;
        }

        [BindProperty(SupportsGet = true)]
        public TransactionFilter Filter { get; set; }

        public List<GetTransactionDto> Transactions { get; set; }
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var response = await _TransactionService.GetTransactionsAsync(Filter);
                Transactions = response.Data;
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