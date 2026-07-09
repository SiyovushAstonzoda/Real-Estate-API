using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PopularLocationsController : ControllerBase
{
    private readonly IPopularLocationRepository _popularLocationRepository;

    public PopularLocationsController(IPopularLocationRepository popularLocationRepository)
    {
        _popularLocationRepository = popularLocationRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
    {
        await _popularLocationRepository.CreatePopularLocation(popularLocationDto);
        return Ok("New PopularLocation has been created");
    }

    [HttpGet]
    public async Task<IActionResult> PopularLocationList()
    {
        var values = await _popularLocationRepository.GetAllPopularLocation();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> PopularLocationById(int id)
    {
        var value = await _popularLocationRepository.GetPopularLocationByID(id);
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
    {
        await _popularLocationRepository.UpdatePopularLocation(popularLocationDto);
        return Ok("PopularLocation has been updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePopularLocation(int id)
    {
        await _popularLocationRepository.DeletePopularLocation(id);
        return Ok("PopularLocation with Id = " + id + " has been deleted");
    }
}
