using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class AdsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public AdsController(IHttpClientFactory httpClientFactory, ILoginService loginService = null)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IActionResult> ActiveAds()
        {
            var id = _loginService.GetUserID;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5048/api/Products/GetProductAdsListByEmployeeByTrue?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdsListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> PassiveAds()
        {
            var id = _loginService.GetUserID;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5048/api/Products/GetProductAdsListByEmployeeByFalse?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdsListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAd()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5048/api/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryID.ToString()
                                                   }).ToList();
            ViewBag.v = categoryValues;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAd(CreateProductDto createProductDto)
        {
            createProductDto.DealOfTheDay = false;
            createProductDto.AnnouncementDate = DateTime.Now;
            createProductDto.Status = true;

            var id = _loginService.GetUserID;
            createProductDto.EmployeeID = int.Parse(id);

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5048/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
