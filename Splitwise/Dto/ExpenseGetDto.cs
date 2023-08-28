namespace Splitwise.Dto;

public class ExpenseGetDto
{
    public ExpenseGetDto(int expenseId)
    {
        Id = expenseId;
    }

    public int Id { get; }
}