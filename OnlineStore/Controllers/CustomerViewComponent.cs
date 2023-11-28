using Microsoft.AspNetCore.Mvc;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Entities;

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
        public  IViewComponentResult Invoke(int UserId,CancellationToken cancellationToken)
        {
            var customer = _userAppService.GetById(UserId , cancellationToken);
            return View("Default", customer);
        }
    }
}
