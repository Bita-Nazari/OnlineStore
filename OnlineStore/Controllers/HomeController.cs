using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using System.Diagnostics;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductAppService _productAppService;
        public HomeController(ILogger<HomeController> logger , IProductAppService productAppService)
        {
            _logger = logger;
            _productAppService = productAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var productList = await _productAppService.GetAll(cancellationToken);
            var productViewModelList = productList.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,

            }).ToList();

            return View(productViewModelList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}