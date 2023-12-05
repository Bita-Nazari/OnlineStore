using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using System.Security.Claims;
using System.Threading;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class BidController : Controller
    {

        private readonly IBidAppService _bidAppService;
        private readonly ICustomerAppService _customerAppService;
        public BidController(IBidAppService bidAppService, ICustomerAppService customerAppService)
        {
            _bidAppService = bidAppService;
            _customerAppService = customerAppService;

        }
        public async Task<IActionResult> Bid(int id, int CustomerId , CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
            if (customer.Address == null && customer.CityId == null && customer.FirstName == null && customer.FirstName == null)
            {
                return RedirectToAction("Edit", "Profile", new { id = customer.Id });
            }
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
