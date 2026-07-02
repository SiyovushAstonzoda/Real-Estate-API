using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EstateAgentChartController : ControllerBase
{
    private readonly IChartRepository _chartRepository;

    public EstateAgentChartController(IChartRepository chartRepository)
    {
        _chartRepository = chartRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCityCountChart()
    {
        var values = await _chartRepository.GetCityCountChart();
        return Ok(values);
    }
}
