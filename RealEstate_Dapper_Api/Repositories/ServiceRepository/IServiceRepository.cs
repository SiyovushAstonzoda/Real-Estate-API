using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository;

public interface IServiceRepository
{
    void CreateService(CreateServiceDto serviceDto);
    Task<List<ResultServiceDto>> GetAllServiceAsync();
    Task<GetByIDServiceDto> GetServiceByID(int id);
    void UpdateService(UpdateServiceDto serviceDto);
    void DeleteService(int id);
}
