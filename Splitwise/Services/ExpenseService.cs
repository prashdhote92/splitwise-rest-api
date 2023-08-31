using AutoMapper;
using Splitwise.Dto;
using Splitwise.Models;
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

    public ServiceResult<Expense> Get(int expenseId)
    {
        var expense = _expenseRepository.Get(expenseId);
        return expense == null
            ? new ServiceResult<Expense>(new Error(Constants.ExpenseNotExists))
            : new ServiceResult<Expense>(expense);
    }

    public ServiceResult<int> Create(ExpensePostDto expensePostDto)
    {
        var expense = _mapper.Map<Expense>(expensePostDto);
        expense.Id = _expenseRepository.GetNextId();
        var expenseId = _expenseRepository.Add(expense);
        return expenseId > -1
            ? new ServiceResult<int>(expense.Id)
            : new ServiceResult<int>(new Error(Constants.ExpenseCreationFailed));
    }
}

public interface IExpenseRepository
{
    int GetNextId();
    int Add(Expense expense);
    Expense Get(int expenseId);
}

public class ExpenseRepository : IExpenseRepository
{
    private readonly Dictionary<int, Expense> _expenseTable = new Dictionary<int, Expense>();

    public int GetNextId()
    {
        return _expenseTable.Keys.LastOrDefault() + 1;
    }

    public int Add(Expense expense)
    {
        _expenseTable.Add(expense.Id, expense);
        return expense.Id;
    }

    public Expense Get(int expenseId)
    {
        _expenseTable.TryGetValue(expenseId, out var expense);
        return expense;
    }
}