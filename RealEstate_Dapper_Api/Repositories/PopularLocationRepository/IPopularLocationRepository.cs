using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepository;

public interface IPopularLocationRepository
{
    Task CreatePopularLocation(CreatePopularLocationDto popularLocationDto);
    Task<List<ResultPopularLocationDto>> GetAllPopularLocation();
    Task<GetByIDPopularLocationDto> GetPopularLocationByID(int id);
    Task UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto);
    Task DeletePopularLocation(int id);
}
