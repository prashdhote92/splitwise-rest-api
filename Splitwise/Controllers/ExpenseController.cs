using Microsoft.AspNetCore.Mvc;
using Splitwise.Dto;

namespace Splitwise.Controllers;

[ApiController]
[Route("expense")]
public class ExpenseController : ControllerBase
{
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
            Timestamp = DateTime.Now,
        };
    }
}