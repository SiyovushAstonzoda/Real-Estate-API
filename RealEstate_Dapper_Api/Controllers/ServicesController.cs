using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IServiceRepository _serviceRepository;

    public ServicesController(IServiceRepository serviceRepository)
    {
        _serviceRepository = serviceRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateService(CreateServiceDto serviceDto)
    {
        _serviceRepository.CreateService(serviceDto);
        return Ok("New Service has been created");
    }

    [HttpGet]
    public async Task<IActionResult> ServiceList()
    {
        var values = await _serviceRepository.GetAllServiceAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ServiceById(int id)
    {
        var value = await _serviceRepository.GetServiceByID(id);
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateService(UpdateServiceDto serviceDto)
    {
        _serviceRepository.UpdateService(serviceDto);
        return Ok("Service has been updated");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteService(int id)
    {
        _serviceRepository.DeleteService(id);
        return Ok("Service with Id = " + id + " has been deleted");
    }
}
