using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository;

public class ServiceRepository : IServiceRepository
{
    private readonly Context _context;

    public ServiceRepository(Context context)
    {
        _context = context;
    }

    public async void CreateService(CreateServiceDto serviceDto)
    {
        string query = "Insert into Service (Name, Status) values (@name, @status)";
        var parameters = new DynamicParameters();
        parameters.Add("@name", serviceDto.Name);
        parameters.Add("@status", serviceDto.Status);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteService(int id)
    {
        string query = "Delete From Service Where ServiceID = @serviceID";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultServiceDto>> GetAllServiceAsync()
    {
        string query = "Select * from Service";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultServiceDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIDServiceDto> GetServiceByID(int id)
    {
        string query = "Select * From Service Where ServiceID=@serviceID";
        var parameters = new DynamicParameters();
        parameters.Add("@serviceID", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, parameters);
            return value;
        }
    }

    public async void UpdateService(UpdateServiceDto serviceDto)
    {
        string query = "Update Service Set Name=@name,Status=@status Where ServiceID=@serviceID";
        var parameters = new DynamicParameters();
        parameters.Add("@name", serviceDto.Name);
        parameters.Add("@status", serviceDto.Status);
        parameters.Add("@serviceID", serviceDto.ServiceID);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
