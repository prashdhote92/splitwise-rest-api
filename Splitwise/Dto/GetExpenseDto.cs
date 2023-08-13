namespace Splitwise.Dto;

public class GetExpenseDto
{
    public User User { get; set; }
    public DateTime Timestamp { get; set; }
    public string Id { get; set; }
}