using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepository;

public interface IToDoListRepository
{
    void CreateToDoList(CreateToDoListDto toDoListDto);
    Task<List<ResultToDoListDto>> GetAllToDoListsAsync();
    Task<GetByIDToDoListDto> GetToDoListByID(int id);
    void UpdateToDoList(UpdateToDoListDto toDoListDto);
    void DeleteToDoList(int id);
}
