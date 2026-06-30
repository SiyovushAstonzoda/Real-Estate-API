using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
    [Area("EstateAgent")]
    public class AdsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}
