using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using RealEstate_Dapper_Api.Dtos.AboutDtos;
using RealEstate_Dapper_Api.Repositories.AboutRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AboutController : ControllerBase
{
    private readonly IAboutRepository _aboutRepository;

    public AboutController(IAboutRepository aboutRepository)
    {
        _aboutRepository = aboutRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAbout(CreateAboutDto aboutDto)
    {
        _aboutRepository.CreateAbout(aboutDto);
        return Ok("New About has been created");
    }

    [HttpGet]
    public async Task<IActionResult> AboutList()
    {
        var values = await _aboutRepository.GetAllAboutAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> AboutById(int id)
    {
        var value = await _aboutRepository.GetAboutByID(id);
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAbout(UpdateAboutDto aboutDto)
    {
        _aboutRepository.UpdateAbout(aboutDto);
        return Ok("About has been updated");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAbout(int id)
    {
        _aboutRepository.DeleteAbout(id);
        return Ok("About with Id = " + id + " has been deleted");
    }
}
