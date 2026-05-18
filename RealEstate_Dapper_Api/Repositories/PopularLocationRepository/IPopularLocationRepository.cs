using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

public interface IPopularLocationRepository
{
    void CreatePopularLocation(CreatePopularLocationDto popularLocationDto);
    Task<List<ResultPopularLocationDto>> GetAllPopularLocationAsync();
    Task<GetByIDPopularLocationDto> GetPopularLocationByID(int id);
    void UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto);
    void DeletePopularLocation(int id);
}
