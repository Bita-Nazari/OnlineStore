﻿using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OnlineStore.Areas.Seller.Models;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using System.Security.Claims;
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

        public async Task< IActionResult >Profile( CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
            var customerView = new CustomerViewModel()
            {
                Id = customer.Id,
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
        public async Task<IActionResult> Edit( CancellationToken cancellationToken)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var customer = await _customerAppService.GetCustomerByUserId(userId, cancellationToken);
            var cities = await _cityAppService.GetAll(cancellationToken);
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
                Address = customer.Address, 
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
        public async Task<IActionResult> Edit(AllUserViewModel user,IFormFile file, CancellationToken cancellationToken)
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
                PictureUrl = user.PictureUrl,

            };
            await _customerAppService.EditCustomer(customer, file,cancellationToken);
            return RedirectToAction("Profile", new { Id = user.Id });
        }
    }
}
