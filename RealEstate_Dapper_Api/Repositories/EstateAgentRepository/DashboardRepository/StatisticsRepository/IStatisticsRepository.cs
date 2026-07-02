namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticsRepository;

public interface IStatisticsRepository
{
    int ProductCountByEmployeeID(int id);
    int ProductCountByStatusTrue(int id);
    int ProductCountByStatusFalse(int id);
    int AllProductCount();
}
