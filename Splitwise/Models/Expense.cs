namespace Splitwise.Models;

public class Expense
{
    public Expense(int expenseId)
    {
        Id = expenseId;
    }

    public int Id { get; }
    public DateTime ProcessedOn { get; set; }
}