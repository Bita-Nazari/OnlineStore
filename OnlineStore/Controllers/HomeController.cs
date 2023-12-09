using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using System.Diagnostics;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductAppService _productAppService;
        private readonly IUserAppService _userAppService;
        
        public HomeController(ILogger<HomeController> logger , IProductAppService productAppService , IUserAppService user)
        {
            _logger = logger;
            _productAppService = productAppService;
            _userAppService = user;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
           

            //if(id == 0)
            //{
            //   await _userAppService.LogOut(cancellationToken);

            //}


            var productList = await _productAppService.GetAll(cancellationToken);
            var productViewModelList = productList.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                Description = x.Description,
                ProductPictures = x.Pictures,

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