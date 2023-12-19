using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using System.Security.Claims;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class DashbordController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly IAdminAppService _adminAppService;

        public DashbordController(IUserAppService userAppService , IAdminAppService adminAppService)
        {
            _userAppService = userAppService;
            _adminAppService = adminAppService;
        }
       
        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(int id , CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userAppService.GetById(userId, cancellationToken);
            var info = await _adminAppService.Info(cancellationToken);
            var usermodel = new UserViewModel()
            {
                Id = userId,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                CommentCount = info.CommentCount,
                CustomerCount = info.CustomerCount,
                BoothCount = info.BoothCount,
                OrderCount = info.OrderCount,
                

            };
            return View(usermodel);
        }
 


    }
}
