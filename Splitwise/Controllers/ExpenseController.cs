using Microsoft.AspNetCore.Mvc;
using Splitwise.Dto;

namespace Splitwise.Controllers;

[ApiController]
[Route("expense")]
public class ExpenseController : ControllerBase
{
    private readonly ILogger<ExpenseController> _logger;
    private readonly AppSettings _appSettings;

    public ExpenseController(ILogger<ExpenseController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "{id}")]
    public GetExpenseDto Get(string id)
    {
        throw new Exception("Heelo");
        return new GetExpenseDto()
        {
            Id = id,
            User = new User(),
            Timestamp = DateTime.Now,
        };
    }
}