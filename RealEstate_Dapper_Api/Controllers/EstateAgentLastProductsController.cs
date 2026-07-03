using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstateAgentLastProductsController : ControllerBase
{
    private readonly ILastProductsRepository _lastProductsRepository;

    public EstateAgentLastProductsController(ILastProductsRepository lastProductsRepository)
    {
        _lastProductsRepository = lastProductsRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetLastProductsWithCategory(int id)
    {
        var values = await _lastProductsRepository.GetLastProductsWithCategory(id);
        return Ok(values);
    }
}
