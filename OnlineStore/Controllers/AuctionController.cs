using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Entities;
using System.Security.Claims;
using System.Threading;

namespace OnlineStore.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionAppService _auctionAppService;
        private readonly ICustomerAppService _customerAppService;
        public AuctionController(IAuctionAppService auctionAppService , ICustomerAppService customerAppService)
        {
            _auctionAppService = auctionAppService;
            _customerAppService = customerAppService;
        }
        public async Task<IActionResult> AuctionList(CancellationToken cancellationToken)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
                var auctions = await _auctionAppService.GetAll(cancellationToken);
                var list = auctions.Select(a => new AuctionViewModel()
                {
                    Id = a.Id,
                    ProductName = a.ProductName,
                    StartPrice = a.StartPrice,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    SubCategoryName = a.SubcategoryName,
                    Description = a.Description,
                    pictures = a.Pictures,
                    CustomerId = customer.Id
                    ,
                    

                }).ToList();
                return View(list);


            }
            else
            {
                var auctions = await _auctionAppService.GetAll(cancellationToken);
                var list = auctions.Select(a => new AuctionViewModel()
                {
                    Id = a.Id,
                    ProductName = a.ProductName,
                    StartPrice = a.StartPrice,
                    StartTime = a.StartTime,
                    EndTime = a.EndTime,
                    SubCategoryName = a.SubcategoryName,
                    Description = a.Description,
                    pictures = a.Pictures,

                }).ToList();
                return View(list);
            }

        }
        public async Task<IActionResult> Auction(int id, CancellationToken cancellationToken)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
                var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
                var auction = await _auctionAppService.GetDetail(id, cancellationToken);
                var productView = new AuctionViewModel()
                {
                    Id = auction.Id,
                    EndTime = auction.EndTime,
                    StartPrice = auction.StartPrice,
                    StartTime = auction.StartTime,
                    SubCategoryName = auction.SubcategoryName,
                    Description = auction.Description,
                    pictures = auction.Pictures
                    ,
                    ProductName = auction.ProductName,
                    BoothId = auction.BoothId,
                    BoothName = auction.BoothName,
                    CustomerId = customer.Id



                };
                return View(productView);
            }
            else
            {
                var auction = await _auctionAppService.GetDetail(id, cancellationToken);
                var productView = new AuctionViewModel()
                {
                    Id = auction.Id,
                    EndTime = auction.EndTime,
                    StartPrice = auction.StartPrice,
                    StartTime = auction.StartTime,
                    SubCategoryName = auction.SubcategoryName,
                    Description = auction.Description,
                    pictures = auction.Pictures
                    ,
                    ProductName = auction.ProductName,
                    BoothId = auction.BoothId,
                    BoothName = auction.BoothName,
                   



                };
                return View(productView);

            }
                

        }
    }
}
