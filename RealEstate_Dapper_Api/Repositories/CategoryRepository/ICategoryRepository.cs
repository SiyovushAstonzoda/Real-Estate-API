using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    void CreateCategory(CreateCategoryDto categoryDto);
}
