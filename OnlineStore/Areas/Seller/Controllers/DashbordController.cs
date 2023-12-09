using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using System.Security.Claims;
using System.Threading;

namespace OnlineStore.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class DashbordController : Controller
    {
        private readonly IUserAppService _userAppService;
        public DashbordController(IUserAppService userAppService)
        {
            _userAppService = userAppService;  
        }
        public async Task<IActionResult> Index(int id , CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _userAppService.GetById(userId, cancellationToken);
            var usermodel = new UserViewModel()
            {
                Id = userId,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                SellerId = user.SellerId,

            };
            return View(usermodel);

        }
    }

}
