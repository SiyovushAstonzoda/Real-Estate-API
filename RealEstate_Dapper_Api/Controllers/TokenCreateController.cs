using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TokenCreateController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateToken(GetCheckAppUserViewModel model)
    {
        var values = JwtTokenGenerator.GenerateToken(model);
        return Ok(values);
    }
}
