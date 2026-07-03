using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository;

public class LastProductsRepository : ILastProductsRepository
{
    private readonly Context _context;

    public LastProductsRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ResultLastProductsWithCategoryDto>> GetLastProductsWithCategory(int id)
    {
        string query = @"Select Top(5) p.ProductID, p.Title, p.Price, p.City, p.District, c.CategoryName, p.AnnouncementDate
                        From Product p
                        Inner Join Category c On p.ProductCategory = c.CategoryID
                        Where EmployeeID = @employeeID
                        Order By p.ProductID Desc";
        var parameters = new DynamicParameters();
        parameters.Add("@employeeID", id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultLastProductsWithCategoryDto>(query, parameters);
            return values.ToList();
        }
    }
}
