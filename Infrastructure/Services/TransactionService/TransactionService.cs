using System.Data.Common;
using System.Net;
using AutoMapper;
using Domain.DTOs.TransactionDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.TransactionService;

public class TransactionService : ITransactionService
{

    private readonly IMapper _mapper;
    private readonly DataContext _context;

    public TransactionService(IMapper mapper, DataContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public async Task<PagedResponse<List<GetTransactionDto>>> GetTransactionsAsync(PaginationFilter filter)
    {
        try
        {
            var transactions = _context.Transactions.AsQueryable();

            var result = await transactions.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize)
               .ToListAsync();
            var total = await transactions.CountAsync();

            var response = _mapper.Map<List<GetTransactionDto>>(result);
            return new PagedResponse<List<GetTransactionDto>>(response, total, filter.PageNumber, filter.PageSize);
        }
        catch (Exception e)
        {
            return new PagedResponse<List<GetTransactionDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }




    public async Task<Response<GetTransactionDto>> GetTransactionByIdAsync(int TransactionId)
    {
        try
        {
            var existing = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == TransactionId);
            if (existing == null) return new Response<GetTransactionDto>(HttpStatusCode.BadRequest, "Transaction not found");
            var Transaction = _mapper.Map<GetTransactionDto>(existing);
            return new Response<GetTransactionDto>(Transaction);
        }
        catch (Exception e)
        {
            return new Response<GetTransactionDto>(HttpStatusCode.InternalServerError, e.Message);
        }
    }


    public async Task<Response<string>> CreateTransactionAsync(CreateTransactionDto transaction)
    {
        try
        {
            var existing = await _context.Accounts.FirstOrDefaultAsync(x => x.Id==transaction.FromAccountId );
            var existingUser = await _context.Accounts.FirstOrDefaultAsync(e => e.Id == transaction.ToAccountId);
            if (existing==null || transaction.Amount <= 0 || existingUser == null) return new Response<string>(HttpStatusCode.BadRequest, "User not found");
            if (existing.Balance>=transaction.Amount)
            {
                existing.Balance-=transaction.Amount;
                existingUser.Balance+= transaction.Amount;
                await _context.SaveChangesAsync();
                
            }
            var newTransaction = _mapper.Map<Transaction>(transaction);
            await _context.Transactions.AddAsync(newTransaction);
            await _context.SaveChangesAsync();
            return new Response<string>("Successfully created ");
        }
        catch (DbException e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }


    public async Task<Response<string>> UpdateTransactionAsync(UpdateTransactionDto Transaction)
    {
        try
        {
            var existing = await _context.Transactions.AnyAsync(x => x.Id == Transaction.Id);
            if (!existing) return new Response<string>(HttpStatusCode.BadRequest, "Transaction not found");
            var newTransaction = _mapper.Map<Transaction>(Transaction);
            _context.Transactions.Update(newTransaction);
            await _context.SaveChangesAsync();
            return new Response<string>("Transaction successfully updated");
        }
        catch (DbException e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
        catch (Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> RemoveTransactionAsync(int TransactionId)
    {
        try
        {
            var existing = await _context.Transactions.Where(x => x.Id == TransactionId).ExecuteDeleteAsync();
            if (existing == 0)
            {
                return new Response<bool>(HttpStatusCode.BadRequest, "Transaction not found");
            }
            return new Response<bool>(true);
        }
        catch (DbException e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
        catch (Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

}