using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Splitwise.Dto;
using Splitwise.Services;

namespace Splitwise.Controllers;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public JsonResult Create([FromBody, Required] UserPostDto userPostDto)
    {
        var result = _userService.Create(userPostDto);
        if (result.IsError)
        {
            _logger.Log(Microsoft.Extensions.Logging.LogLevel.Error, "can not create", result.Error);
            return new JsonResult(result.Error.Message) {StatusCode = (int) HttpStatusCode.BadRequest};
        }

        return new JsonResult($"/user/{result.Value}") {StatusCode = (int) HttpStatusCode.Created};
    }
    [Authorize]
    [HttpGet("{userId}")]
    public JsonResult Get([FromRoute, Required] string userId)
    {
        var user = _userService.Get(userId);
        if (user.IsError)
        {
            _logger.Log(Microsoft.Extensions.Logging.LogLevel.Error, "can not GET");
            return new JsonResult(user.Error) {StatusCode = (int) HttpStatusCode.BadRequest};
        }

        return new JsonResult(user.Value) {StatusCode = (int) HttpStatusCode.OK};
    }
}