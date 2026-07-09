using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository;

public interface IEmployeeRepository
{
    Task CreateEmployee(CreateEmployeeDto employeeDto);
    Task<List<ResultEmployeeDto>> GetAllEmployees();
    Task<GetByIDEmployeeDto> GetEmployeeByID(int id);
    Task UpdateEmployee(UpdateEmployeeDto employeeDto);
    Task DeleteEmployee(int id);
}
