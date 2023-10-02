using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Splitwise.Controllers;

//todo move to Identity Server
[Route("secure")]
public class IdentityController : ControllerBase
{
    //todo Move to Secret Manager
    private const string TokenSecret = "SplitwiseJWTSecretKey";
    private static readonly TimeSpan TokenTimeSpan = TimeSpan.FromHours(8);

    private readonly AppSettings _appSettings;

    public IdentityController(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }
    
    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] TokenGenerationRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(TokenSecret);

        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, request.Email),
            new Claim(JwtRegisteredClaimNames.Email, request.Email),
            new Claim("userId", request.UserId)
        };

        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.Add(TokenTimeSpan),
            Issuer = _appSettings.JwtSetting.Issuer,
            Audience = _appSettings.JwtSetting.Audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);
        return Ok(jwt);
    }
}

public class TokenGenerationRequest
{
    public string Email { get; set; }
    public string UserId { get; set; }
}