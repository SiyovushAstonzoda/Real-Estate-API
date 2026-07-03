using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
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

    [HttpGet("GetLastRentedProductsWithCategory")]
    public async Task<IActionResult> GetLastRentedProductsWithCategory()
    {
        var values = await _productRepository.GetLastRentedProductsWithCategory();
        return Ok(values);
    }

    [HttpGet("GetProductAdsListByEmployeeByTrue")]
    public async Task<IActionResult> GetProductAdsListByEmployeeByTrue(int id)
    {
        var values = await _productRepository.GetProductAdsListByEmployeeByTrue(id);
        return Ok(values);
    }

    [HttpGet("GetProductAdsListByEmployeeByFalse")]
    public async Task<IActionResult> GetProductAdsListByEmployeeByFalse(int id)
    {
        var values = await _productRepository.GetProductAdsListByEmployeeByFalse(id);
        return Ok(values);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductDto productDto)
    {
        await _productRepository.CreateProduct(productDto);
        return Ok("New Product has been created successfully");
    }
}
