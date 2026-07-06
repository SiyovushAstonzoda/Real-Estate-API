using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductImageController : ControllerBase
{
    private readonly IProductImageRepository _productImageRepository;

    public ProductImageController(IProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }

    [HttpGet("GetProductImagesByID")]
    public async Task<IActionResult> GetProductImagesByID(int id)
    {
        var values = await _productImageRepository.GetProductImagesByID(id);
        return Ok(values);
    }
}
