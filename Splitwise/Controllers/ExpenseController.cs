using System.Net;
using Microsoft.AspNetCore.Mvc;
using Splitwise.Dto;
using Splitwise.Services;
using Splitwise.Shared;

namespace Splitwise.Controllers;

[ApiController]
[Route("expense")]
public class ExpenseController : ControllerBase
{
    private readonly ILogger<ExpenseController> _logger;
    private readonly IExpenseService _expenseService;

    public ExpenseController(ILogger<ExpenseController> logger, IExpenseService expenseService)
    {
        _logger = logger;
        _expenseService = expenseService;
    }

    [HttpGet("{expenseId}")]
    public JsonResult Get([FromRoute] int expenseId)
    {
        var result = _expenseService.Get(expenseId);
        return result.IsError
            ? new JsonResult(result.Error) {StatusCode = (int) HttpStatusCode.BadRequest}
            : new JsonResult(result.Value.CreateExpenseGetDto()) {StatusCode = (int) HttpStatusCode.OK};
    }

    [HttpPost]
    public JsonResult Create([FromBody] ExpensePostDto expensePostDto)
    {
        var createResult = _expenseService.Create(expensePostDto);
        return createResult.IsError
            ? new JsonResult(createResult.Error) {StatusCode = (int) HttpStatusCode.BadRequest}
            : new JsonResult($"expense/{createResult.Value}") {StatusCode = (int) HttpStatusCode.OK};
    }
}