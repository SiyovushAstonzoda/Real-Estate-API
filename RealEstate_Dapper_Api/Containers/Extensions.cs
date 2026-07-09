using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Repositories.AboutRepository;
using RealEstate_Dapper_Api.Repositories.AppUserRepository;
using RealEstate_Dapper_Api.Repositories.BottomGridRepository;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ContactRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.ChartRepository;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository;
using RealEstate_Dapper_Api.Repositories.MessageRepository;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepository;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;
using RealEstate_Dapper_Api.Repositories.PropertyAmenityRepository;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepository;
using RealEstate_Dapper_Api.Repositories.TestimonialRepository;
using RealEstate_Dapper_Api.Repositories.ToDoListRepository;

namespace RealEstate_Dapper_Api.Containers;

public static class Extensions
{
    public static void ContainerDependencies(this IServiceCollection services)
    {
        services.AddTransient<Context>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<IAboutRepository, AboutRepository>();
        services.AddTransient<IServiceRepository, ServiceRepository>();
        services.AddTransient<IBottomGridRepository, BottomGridRepository>();
        services.AddTransient<IPopularLocationRepository, PopularLocationRepository>();
        services.AddTransient<ITestimonialRepository, TestimonialRepository>();
        services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        services.AddTransient<RealEstate_Dapper_Api.Repositories.StatisticsRepository.IStatisticsRepository, RealEstate_Dapper_Api.Repositories.StatisticsRepository.StatisticsRepository>();
        services.AddTransient<RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticsRepository.IStatisticsRepository, RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticsRepository.StatisticsRepository>();
        services.AddTransient<IContactRepository, ContactRepository>();
        services.AddTransient<IToDoListRepository, ToDoListRepository>();
        services.AddTransient<IChartRepository, ChartRepository>();
        services.AddTransient<ILastProductsRepository, LastProductsRepository>();
        services.AddTransient<IMessageRepository, MessageRepository>();
        services.AddTransient<IProductImageRepository, ProductImageRepository>();
        services.AddTransient<IAppUserRepository, AppUserRepository>();
        services.AddTransient<IPropertyAmenityRepository, PropertyAmenityRepository>();
        services.AddTransient<ISubFeatureRepository, SubFeatureRepository>();
    }
}
