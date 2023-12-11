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
        private readonly IAuctionAppService _auctionAppService;
        private readonly IProductBoothAppService _productBoothAppService;
        
        public HomeController(ILogger<HomeController> logger , IProductAppService productAppService , IUserAppService user ,IAuctionAppService auctionAppService ,IProductBoothAppService productBoothAppService)
        {
            _logger = logger;
            _productAppService = productAppService;
            _userAppService = user;
            _auctionAppService = auctionAppService;
            _productBoothAppService = productBoothAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
           

            //if(id == 0)
            //{
            //   await _userAppService.LogOut(cancellationToken);

            //}


            var productList = await _productBoothAppService.GetAll(cancellationToken);
            var productViewModelList = productList.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.ProductName,
                Price = x.NewPrice,
                Description = x.Description,
                pictures = x.Pictures,
                Count = x.Count,

            }).ToList();

            return View(productViewModelList);
        }
        public async Task<IActionResult> AuctionList(CancellationToken cancellationToken)
        {
            if (User.Identity.IsAuthenticated)
            {
                //var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                //var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
                var auctions = await _auctionAppService.GetAll(cancellationToken);
                var list = auctions.Select(a => new ProductViewModel()
                {
                    Id = a.Id,
                    ProductName = a.ProductName,
                    StartPrice = a.StartPrice,
                    Description = a.Description,
                    pictures = a.Pictures,
               


                }).ToList();
                return View(list);


            }
            else
            {
                var auctions = await _auctionAppService.GetAll(cancellationToken);
                var list = auctions.Select(a => new ProductViewModel()
                {
                    Id = a.Id,
                    ProductName = a.ProductName,
                    StartPrice = a.StartPrice,
                    Description = a.Description,
                    pictures = a.Pictures,



                }).ToList();
                return View(list);
            }

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