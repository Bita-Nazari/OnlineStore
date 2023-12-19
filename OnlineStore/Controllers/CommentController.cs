using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
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
        public IActionResult Create(int orderid, int boothid)
        {
            var comment = new CommentViewModel
            {
                OrderId = orderid,
                BoothId = boothid
            };
            return View(comment);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CommentViewModel commentView, CancellationToken cancellationToken)
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

        public async Task<IActionResult> GetAllCommentBooth(int id, CancellationToken cancellationToken)
        {
            var booth =await _commentAppService.GetAllBoothComment(id, cancellationToken);
            var commentview = new BoothViewModel
            {
                Comments = booth.Comments

            };
            return View(commentview);
        }
        public async Task<IActionResult> GetAllCommentCustomer( CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
            var comments = await _commentAppService.GetAllCustomerComment(customer.Id, cancellationToken);
            var commentview = comments.Select(c => new CommentViewModel
            {
                IsConfirmed = c.IsConfirmed,
                IsDeleted = c.IsDeleted,
                Text= c.Text,
                BoothName = c.BoothName

            }).ToList();
           
            return View(commentview);
        }
    }
}
