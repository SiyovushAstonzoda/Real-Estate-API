using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository;

public interface IEmployeeRepository
{
    void CreateEmployee(CreateEmployeeDto employeeDto);
    Task<List<ResultEmployeeDto>> GetAllEmployeesAsync();
    Task<GetByIDEmployeeDto> GetEmployeeByID(int id);
    void UpdateEmployee(UpdateEmployeeDto employeeDto);
    void DeleteEmployee(int id);
}
