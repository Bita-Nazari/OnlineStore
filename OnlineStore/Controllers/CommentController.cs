using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentAppService _commentAppService;
        private readonly ICustomerAppService _customerAppService;
        public CommentController(ICommentAppService commentAppService, ICustomerAppService customerAppService)
        {
            _commentAppService = commentAppService;   
            _customerAppService = customerAppService;
        }
        public IActionResult Create(int orderid,int boothid)
        {
            var comment = new CommentViewModel
            {
                OrderId = orderid,
                BoothId = boothid
            };
            return View(comment);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommentViewModel commentView , CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
            var commentdto = new CommentDto
            {
                Text = commentView.Text,
                BoothId = commentView.BoothId,
                CustomerId = customer.Id,
                OrderId = commentView.OrderId,
             

            };
            await _commentAppService.Create(commentdto, cancellationToken);
            return RedirectToAction("OrderList", "Order");
        }
    }
}
