using RealEstate_Dapper_Api.Dtos.AboutDtos;

namespace RealEstate_Dapper_Api.Repositories.AboutRepository;

public interface IAboutRepository
{
    void CreateAbout(CreateAboutDto aboutDto);
    Task<List<ResultAboutDto>> GetAllAboutAsync();
    Task<GetByIDAboutDto> GetAboutByID(int id);
    void UpdateAbout(UpdateAboutDto aboutDto);
    void DeleteAbout(int id);
}
