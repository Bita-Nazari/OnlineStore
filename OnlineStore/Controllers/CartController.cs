using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUserAppService _userAppService;
        private readonly ICartAppService _cartAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly ICartProductAppService _cartProductAppService;
        public CartController(IUserAppService userAppService, ICartAppService cartAppService ,ICustomerAppService customerAppService,ICartProductAppService cartProductAppService)
        {
            _userAppService = userAppService;
            _cartAppService = cartAppService;
            _customerAppService = customerAppService;
            _cartProductAppService = cartProductAppService;
        }
       
        public async Task<IActionResult> AddProduct(int id, CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _cartProductAppService.AddProduct(userId, id, cancellationToken);
            return RedirectToAction("Product" , "Product" , new {id = id });
           

        }
        public async Task< IActionResult> Cart(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
            var cart = await _cartAppService.Detail(customer.ActiveCartId, cancellationToken);
            var CartView = new CartViewModel
            {
                Id = cart.Id,
                Products = cart.Products,
                TotalPrice = cart.TotalPrice,
                Pictures = cart.Pictures,
                Wallet = cart.Wallet,

            };
            return View(CartView);
        }
    }
}
