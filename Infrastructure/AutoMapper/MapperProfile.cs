using AutoMapper;
using Domain.DTOs.AccountDTOs;
using Domain.DTOs.CustomerDTOs;

using Domain.DTOs.TransactionDTOs;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
       

        CreateMap<Customer, GetCustomerDto>().ReverseMap();
        CreateMap<Customer, CreateCustomerDto>().ReverseMap();
        CreateMap<Customer, UpdateCustomerDto>().ReverseMap();

        CreateMap<Account, GetAccountDto>().ReverseMap();
        CreateMap<Account, CreateAccountDto>().ReverseMap();
        CreateMap<Account, UpdateAccountDto>().ReverseMap();

        CreateMap<Transaction, GetTransactionDto>().ReverseMap();
        CreateMap<Transaction, CreateTransactionDto>().ReverseMap();
        CreateMap<Transaction, UpdateTransactionDto>().ReverseMap();
    }
}