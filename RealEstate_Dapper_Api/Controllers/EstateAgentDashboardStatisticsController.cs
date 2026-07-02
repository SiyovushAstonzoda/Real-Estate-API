using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticsRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstateAgentDashboardStatisticsController : ControllerBase
{
    private readonly IStatisticsRepository _statisticsRepository;

    public EstateAgentDashboardStatisticsController(IStatisticsRepository statisticsRepository)
    {
        _statisticsRepository = statisticsRepository;
    }

    [HttpGet("AllProductCount")]
    public IActionResult AllProductCount()
    {
        return Ok(_statisticsRepository.AllProductCount());
    }

    [HttpGet("ProductCountByEmployeeID")]
    public IActionResult ProductCountByEmployeeID(int id)
    {
        return Ok(_statisticsRepository.ProductCountByEmployeeID(id));
    }

    [HttpGet("ProductCountByStatusFalse")]
    public IActionResult ProductCountByStatusFalse(int id)
    {
        return Ok(_statisticsRepository.ProductCountByStatusFalse(id));
    }

    [HttpGet("ProductCountByStatusTrue")]
    public IActionResult ProductCountByStatusTrue(int id)
    {
        return Ok(_statisticsRepository.ProductCountByStatusTrue(id));
    }
}
