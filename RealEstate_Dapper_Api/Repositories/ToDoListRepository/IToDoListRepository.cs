using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository;

public interface IToDoListRepository
{
    Task CreateToDoList(CreateToDoListDto toDoListDto);
    Task<List<ResultToDoListDto>> GetAllToDoLists();
    Task<GetByIDToDoListDto> GetToDoListByID(int id);
    Task UpdateToDoList(UpdateToDoListDto toDoListDto);
    Task DeleteToDoList(int id);
}
