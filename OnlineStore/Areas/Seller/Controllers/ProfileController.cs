using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OnlineStore.Areas.Seller.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;

namespace OnlineStore.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class ProfileController : Controller
    {
        private readonly ISellerAppService _sellerAppService;
        private readonly ICityAppService _cityAppService;
        public ProfileController(ISellerAppService sellerAppServic ,ICityAppService cityAppService)
        {
            _sellerAppService = sellerAppServic; 
            _cityAppService = cityAppService;
        }
        public async Task<IActionResult> Profile(int id , CancellationToken cancellationtoken)
        {
            var seller = await _sellerAppService.GetSellerById(id, cancellationtoken);
            var sellerView = new SellerViewModel()
            {
                Id = id,
                FirstName = seller.FirstName,
                LastName = seller.LastName,
                UserName = seller.UserName,
                NationalCode = seller.NationalCode,
                PhoneNumber = seller.PhoneNumber,
                Email = seller.Email,
                CityName = seller.CityName,
                ShabaNumber = seller.ShabaNumber,


            };
            return View(sellerView);
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
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
                //CityName = seller.CityName,
                Password = seller.Password,
                cities = cities.Select(s => new OS.Domain.Core.Entities.City
                {
                    Id = s.Id,
                    Name = s.Name,
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
            return RedirectToAction("Profile" , new { Id = user.Id });
        }
    }
    }
