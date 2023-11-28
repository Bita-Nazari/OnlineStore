using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class BidController : Controller
    {

        private readonly IBidAppService _bidAppService;
        public BidController(IBidAppService bidAppService)
        {
            _bidAppService = bidAppService;
        }
        public IActionResult Bid(int id, int CustomerId)
        {
            var bid = new BidViewModel
            {
                AuctionId = id,
                CustomerId = CustomerId
            };
            return View(bid);
        }
        [HttpPost]
        public async Task<IActionResult> Bid(BidViewModel bidViewModel, CancellationToken cancellationToken)
        {
            var bid = new BidDto
            {
                AuctionId = bidViewModel.AuctionId,
                CustomerId = bidViewModel.CustomerId,
                SuggestedPrice = bidViewModel.SuggestedPrice,
                CreatedAt = DateTime.Now,
            };
            await _bidAppService.Create(bid, cancellationToken);
            return RedirectToAction("Auction", "Auction", new { Id = bidViewModel.AuctionId, CustomerId = bidViewModel.CustomerId });
        }
    }
}
