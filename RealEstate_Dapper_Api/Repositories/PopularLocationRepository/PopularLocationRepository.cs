using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

public class PopularLocationRepository : IPopularLocationRepository
{
    private readonly Context _context;

    public PopularLocationRepository(Context context)
    {
        _context = context;
    }

    public async void CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
    {
        string query = "Insert into PopularLocation (CityName, ImageUrl) values (@cityName, @imageUrl)";
        var parameters = new DynamicParameters();
        parameters.Add("@cityName", popularLocationDto.CityName);
        parameters.Add("@imageUrl", popularLocationDto.ImageUrl);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync()
    {
        string query = "Select * from PopularLocation";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIDPopularLocationDto> GetPopularLocationByID(int id)
    {
        string query = "Select * From PopularLocation Where PopularLocationID=@popularLocationID";
        var parameters = new DynamicParameters();
        parameters.Add("@popularLocationID", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIDPopularLocationDto>(query, parameters);
            return value;
        }
    }

    public async void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
    {
        string query = "Update PopularLocation Set CityName=@cityName,ImageUrl=@imageUrl Where PopularLocationID=@popularLocationID";
        var parameters = new DynamicParameters();
        parameters.Add("@cityName", popularLocationDto.CityName);
        parameters.Add("@imageUrl", popularLocationDto.ImageUrl);
        parameters.Add("@popularLocationID", popularLocationDto.PopularLocationID);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeletePopularLocation(int id)
    {
        string query = "Delete From PopularLocation Where PopularLocationID = @popularLocationID";
        var parameters = new DynamicParameters();
        parameters.Add("@popularLocationID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
