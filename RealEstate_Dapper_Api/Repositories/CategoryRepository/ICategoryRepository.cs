using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository;

public interface ICategoryRepository
{
    void CreateCategory(CreateCategoryDto categoryDto);
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task<GetByIDCategoryDto> GetCategoryByID(int id);
    void UpdateCategory(UpdateCategoryDto categoryDto);
    void DeleteCategory(int id);
}
