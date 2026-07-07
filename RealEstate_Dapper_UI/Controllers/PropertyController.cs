using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailsDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5048/api/Products/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> PropertySingle(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync($"http://localhost:5048/api/Products/GetProductByID?id={id}");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<GetProductByIDDto>(jsonData1);

            var responseMessage2 = await client.GetAsync($"http://localhost:5048/api/ProductDetails/GetProductDetailsByID?id={id}");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            var values2 = JsonConvert.DeserializeObject<GetProductDetailsByIDDto>(jsonData2);

            ViewBag.ProductTitle = values1.Title;
            ViewBag.Price = values1.Price;
            ViewBag.Address = values1.Address;
            ViewBag.Type = values1.Type;
            ViewBag.AnnouncementDate = ((DateTime.Now.Year - values1.AnnouncementDate.Year) * 12) + DateTime.Now.Month - values1.AnnouncementDate.Month;
            ViewBag.PostedOn = (((DateTime)values1.AnnouncementDate).ToString("dd-MMM-yyyy"));
            ViewBag.Description = values1.Description;

            ViewBag.ProductDetailID = values2.ProductDetailID;
            ViewBag.ProductSize = values2.ProductSize;
            ViewBag.RoomCount = values2.RoomCount;
            ViewBag.BedRoomCount = values2.BedRoomCount;
            ViewBag.BathCount = values2.BathCount;
            ViewBag.GarageSize = values2.GarageSize;
            ViewBag.Price = values2.Price;
            ViewBag.BuildYear = values2.BuildYear;
            ViewBag.Location = values2.Location;
            ViewBag.VideoUrl = values2.VideoUrl;

            return View();
        }
    }
}
