using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepository;

public class TestimonialRepository : ITestimonialRepository
{
    private readonly Context _context;

    public TestimonialRepository(Context context)
    {
        _context = context;
    }

    public async void CreateTestimonial(CreateTestimonialDto testimonialDto)
    {
        string query = "Insert into Testimonial (FullName, Title, Comment, Status) values (@fullName, @title, @comment, @status)";
        var parameters = new DynamicParameters();
        parameters.Add("@fullName", testimonialDto.FullName);
        parameters.Add("@title", testimonialDto.Title);
        parameters.Add("@comment", testimonialDto.Comment);
        parameters.Add("@status", testimonialDto.Status);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultTestimonialDto>> GetAllTestimonialAsync()
    {
        string query = "Select * from Testimonial";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultTestimonialDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIDTestimonialDto> GetTestimonialByID(int id)
    {
        string query = "Select * From Testimonial Where TestimonialID=@testimonialID";
        var parameters = new DynamicParameters();
        parameters.Add("@testimonialID", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIDTestimonialDto>(query, parameters);
            return value;
        }
    }

    public async void UpdateTestimonial(UpdateTestimonialDto testimonialDto)
    {
        string query = "Update Testimonial Set FullName=@fullName,Title=@title,Comment=@comment,Status=@status Where TestimonialID=@testimonialID";
        var parameters = new DynamicParameters();
        parameters.Add("@fullName", testimonialDto.FullName);
        parameters.Add("@title", testimonialDto.Title);
        parameters.Add("@comment", testimonialDto.Comment);
        parameters.Add("@status", testimonialDto.Status);
        parameters.Add("@testimonialID", testimonialDto.TestimonialID);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteTestimonial(int id)
    {
        string query = "Delete From Testimonial Where TestimonialID = @testimonialID";
        var parameters = new DynamicParameters();
        parameters.Add("@testimonialID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
