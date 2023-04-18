using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPortal.Controllers
{
    public class AdvertisementController : Controller
    {
        public IActionResult Advertisements()
        {
            return View();
        }
    }
}
