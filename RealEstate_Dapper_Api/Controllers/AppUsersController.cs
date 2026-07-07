using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppUsersController : ControllerBase
{
    private readonly IAppUserRepository _appUserRepository;

    public AppUsersController(IAppUserRepository appUserRepository)
    {
        _appUserRepository = appUserRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAppUserByProductID(int id)
    {
        var value = await _appUserRepository.GetAppUserByProductID(id);
        return Ok(value);
    }
}
