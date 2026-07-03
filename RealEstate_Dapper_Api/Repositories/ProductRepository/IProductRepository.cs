using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository;

public interface IProductRepository
{
    Task<List<ResultProductDto>> GetAllProductsAsync();
    Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    Task ActivateDealOfTheDay(int id);
    Task DeactivateDealOfTheDay(int id);
    Task<List<ResultLastProductsWithCategoryDto>> GetLastRentedProductsWithCategory();
    Task<List<ResultProductAdsListWithCategoryByEmployeeDto>> GetProductAdsListByEmployeeByTrue(int id);
    Task<List<ResultProductAdsListWithCategoryByEmployeeDto>> GetProductAdsListByEmployeeByFalse(int id);
    Task CreateProduct(CreateProductDto createProductDto);
}
