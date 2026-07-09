using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository;

public class ToDoListRepository : IToDoListRepository
{
    private readonly Context _context;

    public ToDoListRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateToDoList(CreateToDoListDto toDoListDto)
    {
        string query = @"Insert Into ToDoList (Description, Status)
                        Values (@description, @status)";
        var parameters = new DynamicParameters();
        parameters.Add("@description", toDoListDto.Description);
        parameters.Add("@status", toDoListDto.Status);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultToDoListDto>> GetAllToDoLists()
    {
        string query = @"Select *
                        From ToDoList";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultToDoListDto>(query);
            return values.ToList();
        }
    }

    public async Task<GetByIDToDoListDto> GetToDoListByID(int id)
    {
        string query = @"Select * 
                        From ToDoList
                        Where ToDoListID=@toDoListID";
        var parameters = new DynamicParameters();
        parameters.Add("@toDoListID", id);
        using (var connection = _context.CreateConnection())
        {
            var value = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query, parameters);
            return value;
        }
    }

    public async Task UpdateToDoList(UpdateToDoListDto toDoListDto)
    {
        string query = @"Update ToDoList 
                        Set Description=@description,Status=@status
                        Where ToDoListID=@toDoListID";
        var parameters = new DynamicParameters();
        parameters.Add("@description", toDoListDto.Description);
        parameters.Add("@status", toDoListDto.Status);
        parameters.Add("@toDoListID", toDoListDto.ToDoListID);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeleteToDoList(int id)
    {
        string query = @"Delete From ToDoList
                        Where ToDoListID = @toDoListID";
        var parameters = new DynamicParameters();
        parameters.Add("@toDoListID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
