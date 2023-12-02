using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.Repository;
using System.Security.Claims;

namespace OnlineStore.Controllers
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICustomerRepository _customerRepository;
        public CartViewComponent(ICartRepository cartRepository , ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }
        public IViewComponentResult Invoke(CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = Task.Run(() => _customerRepository.GetCustomerById(userId, cancellationToken)).Result;
            var cart = Task.Run(() => _cartRepository.Detail(customer.ActiveCartId,cancellationToken)).Result;
            var CartView = new CartViewModel
            {
                Id = cart.Id,
                Products = cart.Products,
                TotalPrice = cart.TotalPrice,
                Pictures = cart.Pictures,
                
            };
            return View("Default", CartView);
        }
    }
}
