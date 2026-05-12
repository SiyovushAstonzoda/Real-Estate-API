using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoriesController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        _categoryRepository.CreateCategory(categoryDto);
        return Ok("New Category has been created");
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var values = await _categoryRepository.GetAllCategoriesAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> CategoryById(int id)
    {
        var value = await _categoryRepository.GetCategoryByID(id);
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
    {
        _categoryRepository.UpdateCategory(categoryDto);
        return Ok("Category has been updated");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        _categoryRepository.DeleteCategory(id);
        return Ok("Category with Id = " + id + " has been deleted");
    }
}
