using Splitwise.Dto;
using Splitwise.Models;
using Splitwise.Shared;

namespace Splitwise.Services;

public interface IExpenseService
{
    ServiceResult<Expense> Get(int expenseId);
    ServiceResult<int> Create(ExpensePostDto expensePostDto);
}