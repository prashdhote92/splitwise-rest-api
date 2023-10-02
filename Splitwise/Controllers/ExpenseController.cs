using System.Net;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splitwise.Dto;
using Splitwise.Services;

namespace Splitwise.Controllers;

[Authorize]
[ApiController]
[Route("expense")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;
    private readonly IMapper _mapper;

    public ExpenseController(IMapper mapper, IExpenseService expenseService)
    {
        _expenseService = expenseService;
        _mapper = mapper;
    }

    [HttpGet("{expenseId}")]
    public JsonResult Get([FromRoute] string expenseId)
    {
        var result = _expenseService.Get(expenseId);
        return result.IsError
            ? new JsonResult(result.Error) {StatusCode = (int) HttpStatusCode.BadRequest}
            : new JsonResult(_mapper.Map<ExpenseGetDto>(result.Value)) {StatusCode = (int) HttpStatusCode.OK};
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