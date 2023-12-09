using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using System.Security.Claims;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly IAdminAppService _adminAppService;
        public ProfileController(IAdminAppService adminAppService)
        {
            _adminAppService = adminAppService;  
        }
        public async Task<IActionResult> Profile(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _adminAppService.GetAdminByUserId(userId, cancellationToken);
            var userview = new AllUserViewModel
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName,
            };
            return View(userview);
        }
        public async Task<IActionResult> Edit(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var Admin = await _adminAppService.GetAdminByUserId(userId, cancellationToken);

            var userviewmodel = new AllUserViewModel
            {
                Id = Admin.Id,
                UserName = Admin.UserName,
                PhoneNumber = Admin.PhoneNumber,
                Email = Admin.Email,
                FirstName = Admin.FirstName,
                LastName = Admin.LastName,

            };
               
            return View(userviewmodel);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(AllUserViewModel user, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var admin = new AlluserDto()
            {
                Id = userId,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,

            };
            await _adminAppService.EditAdmin(admin, cancellationToken);
            return RedirectToAction("Profile", new { Id = user.Id });
        }
    }

}

