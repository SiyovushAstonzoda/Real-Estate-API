using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoListsController : ControllerBase
{
    private readonly IToDoListRepository _toDoListRepository;

    public ToDoListsController(IToDoListRepository toDoListRepository)
    {
        _toDoListRepository = toDoListRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateToDoList(CreateToDoListDto toDoListDto)
    {
        _toDoListRepository.CreateToDoList(toDoListDto);
        return Ok("New ToDoList has been created");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllToDoListsAsync()
    {
        var values = await _toDoListRepository.GetAllToDoListsAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetToDoListByID(int id)
    {
        var value = await _toDoListRepository.GetToDoListByID(id);
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto toDoListDto)
    {
        _toDoListRepository.UpdateToDoList(toDoListDto);
        return Ok("ToDoList has been updated");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteToDoList(int id)
    {
        _toDoListRepository.DeleteToDoList(id);
        return Ok("ToDoList with Id = " + id + " has been deleted");
    }
}
