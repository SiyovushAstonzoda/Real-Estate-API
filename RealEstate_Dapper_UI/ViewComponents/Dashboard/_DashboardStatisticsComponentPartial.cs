using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard;

public class _DashboardStatisticsComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Statistics1 - Product Count
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("http://localhost:5048/api/Statistics/ProductCount");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        ViewBag.ProductCount = jsonData1;
        #endregion

        #region Statistics2 - Employee Name By Max Product Count
        var client2 = _httpClientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("http://localhost:5048/api/Statistics/EmployeeNameByMaxProductCount");
        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        ViewBag.EmployeeNameByMaxProductCount = jsonData2;
        #endregion

        #region Statistics3 - Differen City Count
        var client3 = _httpClientFactory.CreateClient();
        var responseMessage3 = await client3.GetAsync("http://localhost:5048/api/Statistics/DifferentCityCount");
        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
        ViewBag.DifferentCityCount = jsonData3;
        #endregion

        #region Statistics4 - Average Product Price By Rent
        var client4 = _httpClientFactory.CreateClient();
        var responseMessage4 = await client4.GetAsync("http://localhost:5048/api/Statistics/AverageProductPriceByRent");
        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        ViewBag.AverageProductPriceByRent = jsonData4;
        #endregion

        return View();
    }
}
