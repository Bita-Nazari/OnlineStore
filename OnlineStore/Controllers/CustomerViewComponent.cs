using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Entities;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    public class CustomerViewComponent : ViewComponent
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IUserAppService _userAppService;
        public CustomerViewComponent(ICustomerAppService customerAppService, IUserAppService userAppService)
        {
            _customerAppService = customerAppService;
            _userAppService = userAppService;
        }
        public   IViewComponentResult Invoke(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            //var user = User.Identity.Name;

            var User = Task.Run(() => _userAppService.GetById(userId, cancellationToken)).Result;
            var UserView = new UserViewModel
            {
                Id = User.Id
            };
            return View("Default", UserView);
        }
    }
}
