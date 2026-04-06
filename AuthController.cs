using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace StudentManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    public AuthController(IConfiguration config) { _config = config; }

    [HttpPost("login")]
    public IActionResult Login()
    {
        var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]!);
        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddHours(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}
