using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyAmenitiesController : ControllerBase
{
    private readonly IPropertyAmenityRepository _propertyAmenityRepository;

    public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
    {
        _propertyAmenityRepository = propertyAmenityRepository;
    }

    [HttpGet("GetPropertyAmenityByStatusTrue")]
    public async Task<IActionResult> GetPropertyAmenityByStatusTrue(int id)
    {
        var values = await _propertyAmenityRepository.GetPropertyAmenityByStatusTrue(id);
        return Ok(values);
    }
}
