using RealEstate_Dapper_Api.Dtos.BottomGridDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepository;

public interface IBottomGridRepository
{
    void CreateBottomGrid(CreateBottomGridDto bottomGridDto);
    Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
    Task<GetByIDBottomGridDto> GetBottomGridByID(int id);
    void UpdateBottomGrid(UpdateBottomGridDto bottomGridDto);
    void DeleteBottomGrid(int id);
}
