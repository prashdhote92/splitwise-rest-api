using Splitwise.Models;
using Splitwise.Shared;

namespace Splitwise.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly DataContext _dataContext;

    public ExpenseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void Add(Expense expense)
    {
        _dataContext.Expenses.Add(expense);
        _dataContext.SaveChanges();
    }

    public Expense Get(string expenseId)
    {
        return _dataContext.Expenses.FirstOrDefault(x => x.Id == expenseId);
    }
}