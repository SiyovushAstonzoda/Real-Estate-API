namespace RealEstate_Dapper_Api.Repositories.StatisticsRepository;

public interface IStatisticsRepository
{
    int CategoryCount();
    int ActiveCategoryCount();
    int PassiveCategoryCount();
    int ProductCount();
    int ApartmentCount();
    string CategoryNameByMaxProductCount();
    string EmployeeNameByMaxProductCount();
    decimal AverageProductPriceByRent();
    decimal AverageProductPriceBySale();
    string CityNameByMaxProductCount();
    int DifferentCityCount();
    decimal LastProductPrice();
    string NewestBuildingYear();
    string OldestBuildingYear();
    int AverageRoomCount();
    int ActiveEmployeeCount();
}
