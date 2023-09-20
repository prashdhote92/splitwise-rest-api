using Splitwise.Dto;
using Splitwise.Models;
using Splitwise.Shared;

namespace Splitwise.Services;

public interface IExpenseService
{
    ServiceResult<Expense> Get(string expenseId);
    ServiceResult<string> Create(ExpensePostDto expensePostDto);
}