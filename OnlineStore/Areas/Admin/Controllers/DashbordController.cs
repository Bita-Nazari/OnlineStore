using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;

namespace OnlineStore.Areas.Admin.Controllers
{
    public class DashbordController : Controller
    {
        private readonly IUserAppService _userAppService;

        public DashbordController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
       
        [Area("Admin")]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index(int id , CancellationToken cancellationToken)
        {
            var user = await _userAppService.GetById(id , cancellationToken);
            var usermodel = new UserViewModel()
            {
                Id = id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,

            };
            return View(usermodel);
        }
 


    }
}
