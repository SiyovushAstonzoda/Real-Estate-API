using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    Task CreateCategory(CreateCategoryDto categoryDto);
    Task<List<ResultCategoryDto>> GetAllCategories();
    Task<GetByIDCategoryDto> GetCategoryByID(int id);
    Task UpdateCategory(UpdateCategoryDto categoryDto);
    Task DeleteCategory(int id);
}
