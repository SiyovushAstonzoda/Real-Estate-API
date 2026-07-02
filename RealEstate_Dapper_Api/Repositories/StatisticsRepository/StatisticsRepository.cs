using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepository;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly Context _context;

    public StatisticsRepository(Context context)
    {
        _context = context;
    }

    public int ActiveCategoryCount()
    {
        string query = @"Select Count(*) 
                        From Category 
                        Where CategoryStatus = 1";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int ActiveEmployeeCount()
    {
        string query = @"Select Count(*) 
                        From Employee 
                        Where Status = 1";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int ApartmentCount()
    {
        string query = @"Select Count(*) 
                        From Product
                        Where Title Like '%Apartment%'";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public decimal AverageProductPriceByRent()
    {
        string query = @"Select Avg(Price) 
                        From Product
                        Where Type = 'Rent'";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<decimal>(query);
            return values;
        }
    }

    public decimal AverageProductPriceBySale()
    {
        string query = @"Select Avg(Price) 
                        From Product
                        Where Type = 'Sale'";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<decimal>(query);
            return values;
        }
    }

    public int AverageRoomCount()
    {
        string query = @"Select Avg(RoomCount) 
                        From ProductDetails";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int CategoryCount()
    {
        string query = @"Select Count(*) 
                        From Category";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public string CategoryNameByMaxProductCount()
    {
        string query = @"Select Top(1) c.CategoryName 
                        From Product p
                        Inner Join Category c On p.ProductCategory = c.CategoryID 
                        Group By c.CategoryName, p.ProductCategory 
                        Order By Count(*) Desc";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public string CityNameByMaxProductCount()
    {
        string query = @"Select Top(1) City
                        From Product
                        Group By City
                        Order By Count(*) Desc";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public int DifferentCityCount()
    {
        string query = @"Select Count(Distinct(City))
                        From Product";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public string EmployeeNameByMaxProductCount()
    {
        string query = @"Select Top(1) e.Name
                        From Product p
                        Inner Join Employee e On e.EmployeeID = p.EmployeeID
                        Group By e.Name, p.EmployeeID
                        Order By Count(*) Desc";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public decimal LastProductPrice()
    {
        string query = @"Select Top(1) Price 
                        From Product 
                        Order By ProductID Desc";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<decimal>(query);
            return values;
        }
    }

    public string NewestBuildingYear()
    {
        string query = @"Select Max(BuildYear) 
                        From ProductDetails";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public string OldestBuildingYear()
    {
        string query = @"Select Min(BuildYear) 
                        From ProductDetails";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<string>(query);
            return values;
        }
    }

    public int PassiveCategoryCount()
    {
        string query = @"Select Count(*) 
                        From Category 
                        Where CategoryStatus = 0";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }

    public int ProductCount()
    {
        string query = @"Select Count(*)
                        From Product";
        using (var connection = _context.CreateConnection())
        {
            var values = connection.QueryFirstOrDefault<int>(query);
            return values;
        }
    }
}
