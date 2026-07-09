using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SubFeaturesController : ControllerBase
{
    private readonly ISubFeatureRepository _subFeatureRepository;

    public SubFeaturesController(ISubFeatureRepository subFeatureRepository)
    {
        _subFeatureRepository = subFeatureRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllSubFeatures()
    {
        var values = await _subFeatureRepository.GetAllSubFeatures();
        return Ok(values);
    }
}
