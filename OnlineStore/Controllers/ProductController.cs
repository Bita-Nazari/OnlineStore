using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
