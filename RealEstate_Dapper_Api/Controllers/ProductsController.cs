using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ProductList()
    {
        var values = await _productRepository.GetAllProductsAsync();
        return Ok(values);
    }

    [HttpGet("ProductListWithCategory")]
    public async Task<IActionResult> ProductListWithCategory()
    {
        var values = await _productRepository.GetAllProductWithCategoryAsync();
        return Ok(values);
    }

    [HttpPut("ActivateDealOfTheDay/{id}")]
    public async Task<IActionResult> ActivateDealOfTheDay(int id)
    {
        await _productRepository.ActivateDealOfTheDay(id);
        return Ok($"The 'Deal of the Day' status for product ID {id} was successfully activated.");
    }

    [HttpPut("DeactivateDealOfTheDay/{id}")]
    public async Task<IActionResult> DeactivateDealOfTheDay(int id)
    {
        await _productRepository.DeactivateDealOfTheDay(id);
        return Ok($"The 'Deal of the Day' status for product ID {id} was successfully deactivated.");
    }
}
