using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;

namespace RealEstate_Dapper_Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestimonialsController : ControllerBase
{
    private readonly ITestimonialRepository _testimonialRepository;

    public TestimonialsController(ITestimonialRepository testimonialRepository)
    {
        _testimonialRepository = testimonialRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto testimonialDto)
    {
        _testimonialRepository.CreateTestimonial(testimonialDto);
        return Ok("New Testimonial has been created");
    }

    [HttpGet]
    public async Task<IActionResult> TestimonialList()
    {
        var values = await _testimonialRepository.GetAllTestimonialAsync();
        return Ok(values);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> TestimonialById(int id)
    {
        var value = await _testimonialRepository.GetTestimonialByID(id);
        return Ok(value);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto testimonialDto)
    {
        _testimonialRepository.UpdateTestimonial(testimonialDto);
        return Ok("Testimonial has been updated");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTestimonial(int id)
    {
        _testimonialRepository.DeleteTestimonial(id);
        return Ok("Testimonial with Id = " + id + " has been deleted");
    }
}
