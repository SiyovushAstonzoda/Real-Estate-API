using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductDetailsController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductDetailsController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    [HttpGet("GetProductDetailsByID")]
    public async Task<IActionResult> GetProductDetailsByID(int id)
    {
        var values = await _productRepository.GetProductDetailsByID(id);
        return Ok(values);
    }
}
