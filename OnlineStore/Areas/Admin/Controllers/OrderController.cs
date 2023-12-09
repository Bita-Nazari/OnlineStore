using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using OnlineStore.Areas.Admin.Models;
using OS.Domain.Core.Contracts.AppService;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;   
        }
        public async  Task<IActionResult> GetCommession(CancellationToken cancellationToken)
        {
            var orders = await _orderAppService.GetAllCommessionOrders(cancellationToken);
               var orderview = orders.Select(o => new OrderViewModel
               {
                   Commession = o.Commession,
                   CustomerUsername = o.CustomerUsername,
               }).ToList();
            return View(orderview);
        }
    }
}
