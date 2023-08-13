namespace Splitwise.Dto;

public class GetExpenseDto
{
    public string Id { get; set; }
    public User User { get; set; }
    public DateTime Timestamp { get; set; }
}