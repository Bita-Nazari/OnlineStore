using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;

namespace OnlineStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        public async Task<IActionResult> OrderList(int id, CancellationToken cancellationToken)
        {
            
            var orders = await _orderAppService.GetAllCustomerOrder(id, cancellationToken);
            var orderView = orders.Select(o => new OrderViewModel
            {
                CustomerId = o.CustomerId,
                Pictures = o.Pictures,
                ProductBooth = o.ProductBooth,
                TotalPrice = o.TotalPrice,
                StatusName = o.StatusName,

            }).ToList();
            return View(orderView);

        }
    }
}
