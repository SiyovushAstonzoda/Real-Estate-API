using RealEstate_Dapper_Api.Dtos.AboutDtos;

namespace RealEstate_Dapper_Api.Repositories.AboutRepository;

public interface IAboutRepository
{
    Task CreateAbout(CreateAboutDto aboutDto);
    Task<List<ResultAboutDto>> GetAllAbout();
    Task<GetByIDAboutDto> GetAboutByID(int id);
    Task UpdateAbout(UpdateAboutDto aboutDto);
    Task DeleteAbout(int id);
}
