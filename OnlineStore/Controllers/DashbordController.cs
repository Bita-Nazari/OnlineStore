using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;

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

            var user = await _userAppService.GetById(id, cancellationToken);
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
