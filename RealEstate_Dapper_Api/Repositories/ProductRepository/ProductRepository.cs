using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository;

public class ProductRepository : IProductRepository
{
    private readonly Context _context;

    public ProductRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ResultProductDto>> GetAllProductsAsync()
    {
        string query = "Select * From Product";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }
    }

    public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
    {
        string query = @"Select ProductID, Title, Price, CoverImage, City, District, Address, Type, CategoryName, DealOfTheDay
                        From Product 
                        Inner Join Category On Product.ProductCategory=Category.CategoryID";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }
    }

    public async Task ActivateDealOfTheDay(int id)
    {
        string query = @"Update Product 
                        Set DealOfTheDay = 1
                        Where ProductID=@productID";
        var parameters = new DynamicParameters();
        parameters.Add("@productID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task DeactivateDealOfTheDay(int id)
    {
        string query = @"Update Product 
                        Set DealOfTheDay = 0
                        Where ProductID=@productID";
        var parameters = new DynamicParameters();
        parameters.Add("@productID", id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<List<ResultLastProductsWithCategoryDto>> GetLastRentedProductsWithCategory()
    {
        string query = @"Select Top(5) p.ProductID, p.Title, p.Price, p.City, p.District, c.CategoryName, p.AnnouncementDate
                        From Product p
                        Inner Join Category c On p.ProductCategory = c.CategoryID
                        Where Type = 'Rent'
                        Order By p.ProductID Desc";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultLastProductsWithCategoryDto>(query);
            return values.ToList();
        }
    }
}
