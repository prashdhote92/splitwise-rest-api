using AutoMapper;
using Splitwise.Dto;
using Splitwise.Models;
using Splitwise.Repositories;
using Splitwise.Shared;

namespace Splitwise.Services;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IMapper _mapper;

    public ExpenseService(IMapper mapper, IExpenseRepository expenseRepository)
    {
        _expenseRepository = expenseRepository;
        _mapper = mapper;
    }

    public ServiceResult<Expense> Get(string expenseId)
    {
        var expense = _expenseRepository.Get(expenseId);
        return expense == null
            ? new ServiceResult<Expense>(new Error(Constants.ExpenseNotExists))
            : new ServiceResult<Expense>(expense);
    }

    public ServiceResult<string> Create(ExpensePostDto expensePostDto)
    {
        var expense = _mapper.Map<Expense>(expensePostDto);
        expense.Id = "exp-" + Guid.NewGuid();
       _expenseRepository.Add(expense);
       return new ServiceResult<string>(expense.Id);
    }
}