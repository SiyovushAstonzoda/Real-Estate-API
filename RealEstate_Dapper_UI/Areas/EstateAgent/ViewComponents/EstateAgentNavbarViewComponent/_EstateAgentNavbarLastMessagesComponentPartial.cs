using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.MessageDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.ViewComponents.EstateAgentNavbarViewComponent;

public class _EstateAgentNavbarLastMessagesComponentPartial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILoginService _loginService;

    public _EstateAgentNavbarLastMessagesComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
    {
        _httpClientFactory = httpClientFactory;
        _loginService = loginService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var id = _loginService.GetUserID;
        var client = _httpClientFactory.CreateClient();
        var responseMessage = await client.GetAsync($"http://localhost:5048/api/Message/GetInBoxLastMessagesListByReceiver?id={id}");
        if (responseMessage.IsSuccessStatusCode)
        {
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultInBoxMessageDto>>(jsonData);
            return View(values);
        }
        return View();
    }
}
