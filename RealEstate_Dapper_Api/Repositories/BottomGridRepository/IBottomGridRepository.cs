using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository;

public interface IBottomGridRepository
{
    Task CreateBottomGrid(CreateBottomGridDto bottomGridDto);
    Task<List<ResultBottomGridDto>> GetAllBottomGrid();
    Task<GetByIDBottomGridDto> GetBottomGridByID(int id);
    Task UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);
    Task DeleteBottomGrid(int id);
}
