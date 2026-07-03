using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository;

public interface ILastProductsRepository
{
    Task<List<ResultLastProductsWithCategoryDto>> GetLastProductsWithCategory(int id);
}
