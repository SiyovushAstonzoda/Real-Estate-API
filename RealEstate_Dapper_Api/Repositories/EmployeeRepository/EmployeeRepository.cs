using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly Context _context;

    public EmployeeRepository(Context context)
    {
        _context = context;
    }

    public async void CreateEmployee(CreateEmployeeDto employeeDto)
    {
        string query = "insert into Employee (Name, Title, Mail, PhoneNumber, ImageUrl, Status) values (@name, @title, @mail, @phoneNumber, @imageUrl, @status)";
        var parameters = new DynamicParameters();
        parameters.Add("@name", employeeDto.Name);
        parameters.Add("@title", employeeDto.Title);
        parameters.Add("@mail", employeeDto.Mail);
        parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
        parameters.Add("@imageUrl", employeeDto.ImageUrl);
        parameters.Add("@status", true);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultEmployeeDto>> GetAllEmployeesAsync()
    {
        string query = "Select * from Employee";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultEmployeeDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIDEmployeeDto> GetEmployeeByID(int id)
    {
        string query = "Select * From Employee Where EmployeeID=@employeeID";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeID", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIDEmployeeDto>(query, parameters);
            return value;
        }
    }

    public async void UpdateEmployee(UpdateEmployeeDto employeeDto)
    {
        string query = "Update Employee Set Name=@name,Title=@title,Mail=@mail,PhoneNumber=@phoneNumber,ImageUrl=@imageUrl,Status=@status Where EmployeeID=@employeeID";
        var parameters = new DynamicParameters();
        parameters.Add("@name", employeeDto.Name);
        parameters.Add("@title", employeeDto.Title);
        parameters.Add("@mail", employeeDto.Mail);
        parameters.Add("@phoneNumber", employeeDto.PhoneNumber);
        parameters.Add("@imageUrl", employeeDto.ImageUrl);
        parameters.Add("@status", employeeDto.Status);
        parameters.Add("@employeeID", employeeDto.EmployeeID);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async void DeleteEmployee(int id)
    {
        string query = "Delete From Employee Where EmployeeID = @employeeID";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
