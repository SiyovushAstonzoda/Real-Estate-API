using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent;

public class _EstateAgentDashboardLastProductsWithCategoryComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public _EstateAgentDashboardLastProductsWithCategoryComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService = null)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var id = _loginService.GetUserID;

        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:5048/api/EstateAgentLastProducts?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLastProductsWithCategoryDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
