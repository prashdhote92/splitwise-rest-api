using Splitwise.Models;

namespace Splitwise.Repositories;

public interface IExpenseRepository
{
    void Add(Expense expense);
    Expense Get(string expenseId);
}