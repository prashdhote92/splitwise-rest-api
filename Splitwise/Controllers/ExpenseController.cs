using Microsoft.AspNetCore.Mvc;
using Splitwise.Dto;

namespace Splitwise.Controllers;

[ApiController]
[Route("expense")]
public class ExpenseController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ExpenseController> _logger;

    public ExpenseController(ILogger<ExpenseController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "{id}")]
    public GetExpenseDto Get(string id)
    {
        return new GetExpenseDto()
        {
            Id = id,
            User = new User(),
            Timestamp = DateTime.Now,
        };
    }
}