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

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var values = await _categoryRepository.GetAllCategoriesAsync();
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        _categoryRepository.CreateCategory(categoryDto);
        return Ok("New Category has been created");
    }

}
