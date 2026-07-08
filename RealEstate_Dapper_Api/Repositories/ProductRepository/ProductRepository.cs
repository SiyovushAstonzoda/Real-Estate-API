using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailsDtos;
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

    public async Task<List<ResultProductAdsListWithCategoryByEmployeeDto>> GetProductAdsListByEmployeeByTrue(int id)
    {
        string query = @"Select ProductID, Title, Price, CoverImage, City, District, Address, Type, CategoryName, DealOfTheDay
                        From Product 
                        Inner Join Category On Product.ProductCategory=Category.CategoryID
                        Where EmployeeID = @employeeID And Status = 1";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductAdsListWithCategoryByEmployeeDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task<List<ResultProductAdsListWithCategoryByEmployeeDto>> GetProductAdsListByEmployeeByFalse(int id)
    {
        string query = @"Select ProductID, Title, Price, CoverImage, City, District, Address, Type, CategoryName, DealOfTheDay
                        From Product 
                        Inner Join Category On Product.ProductCategory=Category.CategoryID
                        Where EmployeeID = @employeeID And Status = 0";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductAdsListWithCategoryByEmployeeDto>(query, parameters);
            return values.ToList();
        }
    }

    public async Task CreateProduct(CreateProductDto productDto)
    {
        string query = @"Insert Into Product (Title, Price, CoverImage, City, District, Address, Description, ProductCategory, EmployeeID, Type, DealOfTheDay, AnnouncementDate, Status) 
                 Values (@title, @price, @coverImage, @city, @district, @address, @description, @productCategory, @employeeID, @type, @dealOfTheDay, @announcementDate, @status)";

        var parameters = new DynamicParameters();
        parameters.Add("@title", productDto.Title);
        parameters.Add("@price", productDto.Price);
        parameters.Add("@coverImage", productDto.CoverImage);
        parameters.Add("@city", productDto.City);
        parameters.Add("@district", productDto.District);
        parameters.Add("@address", productDto.Address);
        parameters.Add("@description", productDto.Description);
        parameters.Add("@productCategory", productDto.ProductCategory);
        parameters.Add("@employeeID", productDto.EmployeeID);
        parameters.Add("@type", productDto.Type);
        parameters.Add("@dealOfTheDay", productDto.DealOfTheDay);
        parameters.Add("@announcementDate", productDto.AnnouncementDate);
        parameters.Add("@status", productDto.Status);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetProductByIDDto> GetProductByID(int id)
    {
        string query = @"Select ProductID, Title, Price, CoverImage, City, District, Address, Type, CategoryName, DealOfTheDay, AnnouncementDate, Description
                        From Product 
                        Inner Join Category On Product.ProductCategory=Category.CategoryID
                        Where ProductID = @productID";

        var parameters = new DynamicParameters();
        parameters.Add("@productID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<GetProductByIDDto>(query, parameters);
            return values.FirstOrDefault();
        }
    }

    public async Task<GetProductDetailsByIDDto> GetProductDetailsByID(int id)
    {
        string query = @"Select *
                        From ProductDetails
                        Where ProductID = @productID";

        var parameters = new DynamicParameters();
        parameters.Add("@productID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<GetProductDetailsByIDDto>(query, parameters);
            return values.FirstOrDefault();
        }
    }

    public async Task<List<ResultProductWithSearchListDto>> GetProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
    {
        string query = @"SELECT * FROM Product 
                        WHERE Title LIKE @searchKeyValue 
                        AND ProductCategory = @propertyCategoryId 
                        AND City = @city";

        var parameters = new DynamicParameters();
        parameters.Add("@searchKeyValue", $"%{searchKeyValue}%");
        parameters.Add("@propertyCategoryId", propertyCategoryId);
        parameters.Add("@city", city);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
            return values.ToList();
        }
    }
}
