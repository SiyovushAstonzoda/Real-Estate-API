using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AboutDtos;
using RealEstate_Dapper_UI.Dtos.ServiceDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage;

public class _DefaultAboutComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;

    public _DefaultAboutComponentPartial(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var client = _httpClientFactory.CreateClient();
        var client2 = _httpClientFactory.CreateClient();

        var responseMessage = await client.GetAsync("http://localhost:5048/api/About");
        var responseMessage2 = await client2.GetAsync("http://localhost:5048/api/Services");

        if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();

            var value = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
            var value2 = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData2);

            ViewBag.title = value.Select(x => x.Title).FirstOrDefault();
            ViewBag.subtitle = value.Select(x => x.Subtitle).FirstOrDefault();
            ViewBag.description1 = value.Select(x => x.Description1).FirstOrDefault();
            ViewBag.description2 = value.Select(x => x.Description2).FirstOrDefault();
            return View(value2);
        }
        return View();
    }
}
