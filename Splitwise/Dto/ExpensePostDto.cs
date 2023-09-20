namespace Splitwise.Dto;

public class ExpensePostDto
{
    public string Description { get; set; }
    public int Amount { get; set; }
    public string[] PaidBy { get; set; }
    public string[] OwedBy { get; set; }
    public DateTime ProcessedOn { get; set; }
}