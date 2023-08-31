namespace Splitwise.Dto;

public class ExpenseGetDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public int[] PaidBy { get; set; }
    public int[] OwedBy { get; set; }
}