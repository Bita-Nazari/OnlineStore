using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SellerController : Controller
    {
        private readonly ISellerAppService _sellerAppService;
        private readonly ICityAppService _cityAppService;
        public SellerController(ISellerAppService sellerAppService ,ICityAppService cityAppService)
        {
            _sellerAppService = sellerAppService;
            _cityAppService = cityAppService;
        }
        


        public async Task<IActionResult> Seller(CancellationToken cancellationToken)
        {
            var users = await _sellerAppService.GetAllSellers(cancellationToken);
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
        public async Task<IActionResult> Detail(int id, CancellationToken cancellation)
        {
            var seller = await _sellerAppService.GetSellerById(id, cancellation);
            var userviewmodel = new AllUserViewModel
            {
                Id = seller.Id,
                UserName = seller.UserName,
                PhoneNumber = seller.PhoneNumber,
                Email = seller.Email,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
               ShabaNumber = seller.ShabaNumber,
               NationalCode = seller.NationalCode,
                CityName = seller.CityName,
                CreatedAt = seller.CreatedAt,
                Wallet = seller.Wallet,
            };
            return View(userviewmodel);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id ,CancellationToken cancellationToken)
        {
            var cities = await _cityAppService.GetAll(cancellationToken);
            var seller = await _sellerAppService.GetSellerById(id, cancellationToken);
            var userviewmodel = new AllUserViewModel
            {
                Id = seller.Id,
                UserName = seller.UserName,
                PhoneNumber = seller.PhoneNumber,
                Email = seller.Email,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                ShabaNumber = seller.ShabaNumber,
                NationalCode = seller.NationalCode,
                CityName = seller.CityName,
                Password = seller.Password,
                cities = cities.Select(s => new OS.Domain.Core.Entities.City
                {
                    Id=s.Id,
                    Name=s.Name,
                }).ToList(),
                CreatedAt = seller.CreatedAt,
                Wallet = seller.Wallet,
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

            };
            await _sellerAppService.EditSeller(seller, cancellationToken);
            return RedirectToAction("Seller");
        }
        public async Task<IActionResult>Delete(int id , CancellationToken cancellationToken)
        {
            await _sellerAppService.DeleteSeller(id, cancellationToken);
            return RedirectToAction("Seller");
        }
    }
}
