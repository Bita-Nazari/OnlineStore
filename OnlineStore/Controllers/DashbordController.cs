using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    public class DashbordController : Controller
    {
        private readonly IUserAppService _userAppService;
        public DashbordController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        public async Task<IActionResult> Index(int id, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = await _userAppService.GetById(userId, cancellationToken);
            var usermodel = new UserViewModel()
            {
                Id = id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                CustomerId = user.CustomerId,

            };
            return View(usermodel);

        }
    }
}
