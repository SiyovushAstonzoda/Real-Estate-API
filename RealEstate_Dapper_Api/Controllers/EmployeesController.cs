using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeRepository _employeeRepository;

    public EmployeesController(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto employeeDto)
    {
        _employeeRepository.CreateEmployee(employeeDto);
        return Ok("New Employee has been created");
    }

    [HttpGet]
    public async Task<IActionResult> EmployeeList()
    {
        var values = await _employeeRepository.GetAllEmployeesAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> EmployeeById(int id)
    {
        var value = await _employeeRepository.GetEmployeeByID(id);
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto employeeDto)
    {
        _employeeRepository.UpdateEmployee(employeeDto);
        return Ok("Employee has been updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        _employeeRepository.DeleteEmployee(id);
        return Ok("Employee with Id = " + id + " has been deleted");
    }
}
