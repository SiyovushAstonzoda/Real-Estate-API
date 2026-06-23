using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Controllers;

public class StatisticsController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public StatisticsController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        #region Statistics1
        var client1 = _httpClientFactory.CreateClient();
        var responseMessage1 = await client1.GetAsync("http://localhost:5048/api/Statistics/ActiveCategoryCount");
        var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
        ViewBag.ActiveCategoryCount = jsonData1;
        #endregion

        #region Statistics2
        var client2 = _httpClientFactory.CreateClient();
        var responseMessage2 = await client2.GetAsync("http://localhost:5048/api/Statistics/ActiveEmployeeCount");
        var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
        ViewBag.ActiveEmployeeCount = jsonData2;
        #endregion

        #region Statistics3
        var client3 = _httpClientFactory.CreateClient();
        var responseMessage3 = await client3.GetAsync("http://localhost:5048/api/Statistics/ApartmentCount");
        var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
        ViewBag.ApartmentCount = jsonData3;
        #endregion

        #region Statistics4
        var client4 = _httpClientFactory.CreateClient();
        var responseMessage4 = await client4.GetAsync("http://localhost:5048/api/Statistics/AverageProductPriceByRent");
        var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
        ViewBag.AverageProductPriceByRent = jsonData4;
        #endregion

        #region Statistics5
        var client5 = _httpClientFactory.CreateClient();
        var responseMessage5 = await client5.GetAsync("http://localhost:5048/api/Statistics/AverageProductPriceBySale");
        var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
        ViewBag.AverageProductPriceBySale = jsonData5;
        #endregion

        #region Statistics6
        var client6 = _httpClientFactory.CreateClient();
        var responseMessage6 = await client6.GetAsync("http://localhost:5048/api/Statistics/AverageRoomCount");
        var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
        ViewBag.AverageRoomCount = jsonData6;
        #endregion

        #region Statistics7
        var client7 = _httpClientFactory.CreateClient();
        var responseMessage7 = await client7.GetAsync("http://localhost:5048/api/Statistics/CategoryCount");
        var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
        ViewBag.CategoryCount = jsonData7;
        #endregion

        #region Statistics8
        var client8 = _httpClientFactory.CreateClient();
        var responseMessage8 = await client8.GetAsync("http://localhost:5048/api/Statistics/CategoryNameByMaxProductCount");
        var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
        ViewBag.CategoryNameByMaxProductCount = jsonData8;
        #endregion

        #region Statistics9
        var client9 = _httpClientFactory.CreateClient();
        var responseMessage9 = await client9.GetAsync("http://localhost:5048/api/Statistics/CityNameByMaxProductCount");
        var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
        ViewBag.CityNameByMaxProductCount = jsonData9;
        #endregion

        #region Statistics10
        var client10 = _httpClientFactory.CreateClient();
        var responseMessage10 = await client10.GetAsync("http://localhost:5048/api/Statistics/DifferentCityCount");
        var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
        ViewBag.DifferentCityCount = jsonData10;
        #endregion

        #region Statistics11
        var client11 = _httpClientFactory.CreateClient();
        var responseMessage11 = await client11.GetAsync("http://localhost:5048/api/Statistics/EmployeeNameByMaxProductCount");
        var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
        ViewBag.EmployeeNameByMaxProductCount = jsonData11;
        #endregion

        #region Statistics12
        var client12 = _httpClientFactory.CreateClient();
        var responseMessage12 = await client12.GetAsync("http://localhost:5048/api/Statistics/LastProductPrice");
        var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
        ViewBag.LastProductPrice = jsonData12;
        #endregion

        #region Statistics13
        var client13 = _httpClientFactory.CreateClient();
        var responseMessage13 = await client13.GetAsync("http://localhost:5048/api/Statistics/NewestBuildingYear");
        var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
        ViewBag.NewestBuildingYear = jsonData13;
        #endregion

        #region Statistics14
        var client14 = _httpClientFactory.CreateClient();
        var responseMessage14 = await client14.GetAsync("http://localhost:5048/api/Statistics/OldestBuildingYear");
        var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
        ViewBag.OldestBuildingYear = jsonData14;
        #endregion

        #region Statistics15
        var client15 = _httpClientFactory.CreateClient();
        var responseMessage15 = await client15.GetAsync("http://localhost:5048/api/Statistics/PassiveCategoryCount");
        var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
        ViewBag.PassiveCategoryCount = jsonData15;
        #endregion

        #region Statistics16
        var client16 = _httpClientFactory.CreateClient();
        var responseMessage16 = await client16.GetAsync("http://localhost:5048/api/Statistics/ProductCount");
        var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
        ViewBag.ProductCount = jsonData16;
        #endregion

        return View();
    }

}
