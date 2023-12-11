using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using System.Threading;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
       
        private readonly ICustomerAppService _customerAppService;
        private readonly ICityAppService _cityAppService;

        public CustomerController(ICustomerAppService customerAppService ,ICityAppService cityAppService)
        {
            _customerAppService = customerAppService;
            _cityAppService = cityAppService;
        }
       

        public async Task<IActionResult> Customer(CancellationToken cancellationToken)
        {
            var users = await _customerAppService.GetAllCustomers(cancellationToken);
            var userviewModel = users.Select(x => new AllUserViewModel
            {
                Id = x.Id,
                UserName = x.UserName,
                PhoneNumber = x.PhoneNumber,
                Email = x.Email,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsDeleted = x.IsDeleted,
            }).ToList();
            return View(userviewModel);
        }

        public async Task<IActionResult>Detail(int id , CancellationToken cancellation)
        {
            var customer =await _customerAppService.GetCustomerById(id, cancellation);
            
            var userviewmodel = new AllUserViewModel
            {
                Id= customer.Id,
                UserName = customer.UserName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                CityName = customer.CityName,
                CreatedAt = customer.CreatedAt,
                Wallet = customer.Wallet,
            };
            return View(userviewmodel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerAppService.GetCustomerById(id, cancellationToken);
            var cities = await _cityAppService.GetAll(cancellationToken);
            var userviewmodel = new AllUserViewModel
            {
                Id = customer.Id,
                UserName = customer.UserName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
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
            var seller = new AlluserDto()
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
            await _customerAppService.EditCustomer(seller, cancellationToken);
            return RedirectToAction("Customer");
        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _customerAppService.DeleteCustomer(id, cancellationToken);
            return RedirectToAction("Customer");
        }

        public async Task<IActionResult> Restore(int id, CancellationToken cancellationToken)
        {
            await _customerAppService.IsRestored(id, cancellationToken);
            return RedirectToAction("Customer");
        }
    }
}
