using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly ICartAppService _cartAppService;
        public OrderController(IOrderAppService orderAppService, ICustomerAppService customerAppService, ICartAppService cartAppService)
        {
            _orderAppService = orderAppService;
            _customerAppService = customerAppService;
            _cartAppService = cartAppService;
        }
        public async Task<IActionResult> OrderList(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);

            var orders = await _orderAppService.GetAllCustomerOrder(customer.Id, cancellationToken);
            var orderView = orders.Select(o => new OrderViewModel
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                Pictures = o.Pictures,
                ProductBooth = o.ProductBooths,
                TotalPrice = o.TotalPrice,
                StatusName = o.StatusName,

            }).ToList();
            return View(orderView);

        }
        public async Task<IActionResult> OrderAuctionList(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);

            var orders = await _orderAppService.GetAllAuctionOrder(customer.Id, cancellationToken);
            var orderView = orders.Select(o => new OrderViewModel
            {
                Id = o.Id,
                CustomerId = o.CustomerId,
                Pictures = o.Pictures,
                TotalPrice = o.TotalPrice,
                StatusName = o.StatusName,

            }).ToList();
            return View(orderView);

        }
        public async Task<IActionResult> NewOrder(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
            var cart = await _cartAppService.Detail(customer.ActiveCartId, cancellationToken);
            if (customer.Address == null && customer.CityId == null && customer.FirstName == null && customer.FirstName == null)
            {
                return RedirectToAction("Edit", "Profile", new { id = customer.Id });
            }
            if (cart.TotalPrice > customer.Wallet)
            {
                ViewBag.error = "موجودی کافی نیست ";
                return RedirectToAction("Cart", "Cart");
            }
            await _orderAppService.Create(customer.ActiveCartId, cancellationToken);
            await _cartAppService.Create(customer.Id, cancellationToken);
            return RedirectToAction("SuccessPayment", "Order");

        }
        public IActionResult SuccessPayment()
        {
            return View();
        }

        public async Task<IActionResult> OrderDetail(int id, CancellationToken cancellationToken)
        {
            var order = await _orderAppService.Detail(id, cancellationToken);
            var orderview = new OrderDetailViewModel
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                Address = order.Address,
                Email = order.Email,
                FirstName = order.FirstName,
                LastName = order.LastName,
                ProductBooth = order.ProductBooths,
                PhoneNumber = order.PhoneNumber,
                Pictures = order.Pictures,
                StatusName = order.StatusName,
                TotalPrice = order.TotalPrice,

            };
            return View(orderview);

        }
        public async Task<IActionResult> OrderAuctionDetail(int id, CancellationToken cancellationToken)
        {
            var order = await _orderAppService.DetailAuction(id, cancellationToken);
            var orderview = new OrderDetailViewModel
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                Address = order.Address,
                Email = order.Email,
                FirstName = order.FirstName,
                LastName = order.LastName,
                PhoneNumber = order.PhoneNumber,
                Pictures = order.Pictures,
                StatusName = order.StatusName,
                TotalPrice = order.TotalPrice,
                ProductPrice = order.ProductPrice,
                ProductName = order.ProductName,
                BoothId = order.BoothId,

            };
            return View(orderview);

        }
    }
}
