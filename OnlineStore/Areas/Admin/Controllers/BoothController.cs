using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class BoothController : Controller
    {
        public IActionResult Booth()
        {
            return View();
        }
        //[HttpPost]
        //public Task< IActionResult> Booth()
        //{
        //    return View();
        //}
    }
}
