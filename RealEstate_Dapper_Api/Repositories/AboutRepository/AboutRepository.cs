using Dapper;
using RealEstate_Dapper_Api.Dtos.AboutDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AboutRepository;

public class AboutRepository : IAboutRepository
{
    private readonly Context _context;

    public AboutRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateAbout(CreateAboutDto aboutDto)
    {
        string query = "insert into About (Title, Subtitle, Description1, Description2) values (@title, @subtitle, @description1, @description2)";
        var parameters = new DynamicParameters();
        parameters.Add("@title", aboutDto.Title);
        parameters.Add("@subtitle", aboutDto.Subtitle);
        parameters.Add("@description1", aboutDto.Description1);
        parameters.Add("@description2", aboutDto.Description2);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultAboutDto>> GetAllAbout()
    {
        string query = "Select * from About";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultAboutDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIDAboutDto> GetAboutByID(int id)
    {
        string query = "Select * From About Where AboutID=@aboutID";
        var parameters = new DynamicParameters();
        parameters.Add("@aboutID", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIDAboutDto>(query, parameters);
            return value;
        }
    }

    public async Task UpdateAbout(UpdateAboutDto aboutDto)
    {
        string query = "Update About Set Title=@title,Subtitle=@subtitle,Description1=@description1,Description2=@description2 Where AboutID=@aboutID";
        var parameters = new DynamicParameters();
        parameters.Add("@title", aboutDto.Title);
        parameters.Add("@subtitle", aboutDto.Subtitle);
        parameters.Add("@description1", aboutDto.Description1);
        parameters.Add("@description2", aboutDto.Description2);
        parameters.Add("@aboutID", aboutDto.AboutID);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteAbout(int id)
    {
        string query = "Delete From About Where AboutID = @aboutID";
        var parameters = new DynamicParameters();
        parameters.Add("@aboutID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
