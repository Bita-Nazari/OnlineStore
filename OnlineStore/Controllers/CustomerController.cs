using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IUserAppService _userAppService;
        public CustomerController(ICustomerAppService customerAppService, IUserAppService userAppService)
        {
            _customerAppService = customerAppService;
            _userAppService = userAppService;
        }
       
        

        public IActionResult ChargeWallet( CancellationToken cancellationToken)
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> ChargeWallet(CustomerViewModel customerView, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
             var customerdto = new CustomerDto
            {
                Wallet = customerView.Wallet,
            };
            await _customerAppService.ChargeWallet(customer.Id, customerdto, cancellationToken);
            return RedirectToAction("Index" ,"Dashbord");

        }
    }
}
