using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BottomGridsController : ControllerBase
{
    private readonly IBottomGridRepository _bottomGridRepository;

    public BottomGridsController(IBottomGridRepository bottomGridRepository)
    {
        _bottomGridRepository = bottomGridRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto bottomGridDto)
    {
        _bottomGridRepository.CreateBottomGrid(bottomGridDto);
        return Ok("New BottomGrid has been created");
    }

    [HttpGet]
    public async Task<IActionResult> BottomGridList()
    {
        var values = await _bottomGridRepository.GetAllBottomGridAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BottomGridById(int id)
    {
        var value = await _bottomGridRepository.GetBottomGridByID(id);
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBottomGrid(UpdateBottomGridDto bottomGridDto)
    {
        _bottomGridRepository.UpdateBottomGrid(bottomGridDto);
        return Ok("BottomGrid has been updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBottomGrid(int id)
    {
        _bottomGridRepository.DeleteBottomGrid(id);
        return Ok("BottomGrid with Id = " + id + " has been deleted");
    }
}
