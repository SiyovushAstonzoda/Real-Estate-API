using RealEstate_Dapper_Api.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository;

public interface ITestimonialRepository
{
    void CreateTestimonial(CreateTestimonialDto testimonialDto);
    Task<List<ResultTestimonialDto>> GetAllTestimonialAsync();
    Task<GetByIDTestimonialDto> GetTestimonialByID(int id);
    void UpdateTestimonial(UpdateTestimonialDto testimonialDto);
    void DeleteTestimonial(int id);
}
