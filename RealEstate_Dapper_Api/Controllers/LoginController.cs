using Dapper;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Tools;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly Context _context;

    public LoginController(Context context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
    {
        string query = @"Select *
                        From AppUser
                        Where UserName=@userName and Password=@password";
        string query2 = @"Select UserID
                        From AppUser
                        Where UserName=@userName and Password=@password";
        var parameters = new DynamicParameters();
        parameters.Add("@username", loginDto.Username);
        parameters.Add("@password", loginDto.Password);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query, parameters);
            var values2 = await connection.QueryFirstAsync<GetAppUserIDDto>(query2, parameters);
            if (values != null)
            {
                GetCheckAppUserViewModel model = new GetCheckAppUserViewModel();
                model.UserName = values.Username;
                model.UserId = values2.UserID;
                var token = JwtTokenGenerator.GenerateToken(model);
                return Ok(token);
            }
            else
            {
                return Ok("Unsuccessful");
            }
        }
    }
}
