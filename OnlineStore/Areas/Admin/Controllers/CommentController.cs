using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using System.Threading;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentAppService _commentAppService;
        public CommentController(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;  
        }
        public async Task<IActionResult> Comment(CancellationToken cancellationToken)
        {
            var comment = await _commentAppService.GetAll(cancellationToken);
            var boothViewmodel = comment.Select(x => new CommentViewModel
            {
                Id = x.Id,
                BoothName = x.BoothName,
                CustomerName = x.CustomerName,
                IsConfirmed = x.IsConfirmed,
                IsDeleted = x.IsDeleted,
                Text = x.Text,
            }).ToList();
            return View(boothViewmodel);
        }
        public async Task<IActionResult> Confirm(int id, CancellationToken cancellationToken)
        {
            await _commentAppService.Confirm(id, cancellationToken);
            return RedirectToAction("Comment");
        }

    }
}
