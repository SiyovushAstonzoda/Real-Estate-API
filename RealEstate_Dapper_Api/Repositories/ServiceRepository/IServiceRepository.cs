using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository;

public interface IServiceRepository
{
    Task CreateService(CreateServiceDto serviceDto);
    Task<List<ResultServiceDto>> GetAllService();
    Task<GetByIDServiceDto> GetServiceByID(int id);
    Task UpdateService(UpdateServiceDto serviceDto);
    Task DeleteService(int id);
}
