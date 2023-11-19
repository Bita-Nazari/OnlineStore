using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Seller.Models;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;

namespace OnlineStore.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class BoothController : Controller
    {
        private readonly IBoothAppService _boothAppService;
        private readonly ISellerAppService _sellerAppService;
        public BoothController(IBoothAppService boothAppService , ISellerAppService sellerAppService)
        {
            _boothAppService = boothAppService;
            _sellerAppService = sellerAppService;
            
        }
        public async Task<IActionResult> Index(int id , CancellationToken cancellationToken)
        {
            var seller = await _sellerAppService.GetSellerById(id, cancellationToken);
            var sellerview = new SellerViewModel
            {
                Id = seller.Id,
                HaveBooth = seller.HaveBooth
            }; 
            return View(sellerview);
        }

        public IActionResult Create(int id)
        {
            var boothview = new BoothViewModel
            {

                SellerId = id
            };
            return View(boothview);
        }
        [HttpPost]
        public async Task<IActionResult> Create(BoothViewModel boothView, CancellationToken cancellationToken)
        {
            //var seller = await _sellerAppService.GetSellerById(boothView.SellerId, cancellationToken);
            var booth = new BoothDto
            {
                SellerId = boothView.Id,
                Description = boothView.Description,
                Name = boothView.Name,

            };
            await _boothAppService.Create(booth, cancellationToken);
            return RedirectToAction("Index" , new { Id = boothView.Id });
        }
    }
}
