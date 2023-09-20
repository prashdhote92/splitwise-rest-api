namespace Splitwise.Dto;

public class ExpenseGetDto
{
    public string Id { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public string[] PaidBy { get; set; }
    public string[] OwedBy { get; set; }
}