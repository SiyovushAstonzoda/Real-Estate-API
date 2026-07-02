using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent;

public class _EstateAgentDashboardStatisticsComponentPartial : ViewComponent
{

    private readonly IHttpClientFactory _httpClientFactory;

    public _EstateAgentDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        #region Statistics1 - All Product Count
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("http://localhost:5048/api/EstateAgentDashboardStatistics/AllProductCount");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        ViewBag.AllProductCount = jsonData1;
        #endregion

        #region Statistics2 - Employee's Product Count
        var client2 = _httpClientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("http://localhost:5048/api/EstateAgentDashboardStatistics/ProductCountByEmployeeID?id=1");
        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        ViewBag.EmployeesProductCount = jsonData2;
        #endregion

        #region Statistics3 - Passive Product Count
        var client3 = _httpClientFactory.CreateClient();
        var responseMessage3 = await client3.GetAsync("http://localhost:5048/api/EstateAgentDashboardStatistics/ProductCountByStatusFalse?id=1");
        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
        ViewBag.PassiveProductCount = jsonData3;
        #endregion

        #region Statistics4 - Active Product Count
        var client4 = _httpClientFactory.CreateClient();
        var responseMessage4 = await client4.GetAsync("http://localhost:5048/api/EstateAgentDashboardStatistics/ProductCountByStatusTrue?id=1");
        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        ViewBag.ActiveProductCount = jsonData4;
        #endregion

        return View();
    }
}
