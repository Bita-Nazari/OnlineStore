using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using System.Threading;

namespace OnlineStore.Controllers
{
    public class AuctionController : Controller
    {
        private readonly IAuctionAppService _auctionAppService;
        public AuctionController(IAuctionAppService auctionAppService)
        {
            _auctionAppService = auctionAppService;
        }
        public async Task<IActionResult> AuctionList(CancellationToken cancellationToken)
        {
            var auctions = await _auctionAppService.GetAll( cancellationToken);
            var list = auctions.Select(a => new AuctionViewModel()
            {
                ProductName = a.ProductName,
                StartPrice = a.StartPrice,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                SubCategoryName = a.SubcategoryName,
                Description = a.Description,
                pictures = a.Pictures

            }).ToList();
            return View(list);
        }
    }
}
