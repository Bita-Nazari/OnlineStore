using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OnlineStore.Areas.Seller.Models;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using System.Threading;

namespace OnlineStore.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly ICityAppService _cityAppService;
        public ProfileController(ICustomerAppService customerAppService, ICityAppService cityAppService)
        {
            _customerAppService = customerAppService;
            _cityAppService = cityAppService;

        }

        public async Task< IActionResult >Profile(int id , CancellationToken cancellationToken)
        {
            var customer = await _customerAppService.GetCustomerById(id, cancellationToken);
            var customerView = new CustomerViewModel()
            {
                Id = id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                UserName = customer.UserName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                CityName = customer.CityName,
                Address = customer.Address,
                PictureId = customer.PictureId,
                Wallet = customer.Wallet,


            };
            return View(customerView);
        }
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var cities = await _cityAppService.GetAll(cancellationToken);
            var customer = await _customerAppService.GetCustomerById(id, cancellationToken);
            var userviewmodel = new AllUserViewModel
            {
                Id = customer.Id,
                UserName = customer.UserName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                ShabaNumber = customer.ShabaNumber,
                NationalCode = customer.NationalCode,
                //CityName = seller.CityName,
                Password = customer.Password,
                cities = cities.Select(s => new OS.Domain.Core.Entities.City
                {
                    Id = s.Id,
                    Name = s.Name,
                }).ToList(),
                CreatedAt = customer.CreatedAt,
                Wallet = customer.Wallet,
            };
            return View(userviewmodel);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(AllUserViewModel user, CancellationToken cancellationToken)
        {
            var customer = new AlluserDto()
            {
                Id = user.Id,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                NationalCode = user.NationalCode,
                CityId = user.CityId,
                ShabaNumber = user.ShabaNumber,
                Password = user.Password,
                Address = user.Address,

            };
            await _customerAppService.EditCustomer(customer, cancellationToken);
            return RedirectToAction("Profile", new { Id = user.Id });
        }
    }
}
