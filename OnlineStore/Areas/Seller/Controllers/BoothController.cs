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
        private readonly IProductAppService _productAppService;
        private readonly IProductBoothAppService _productBoothAppService;
        private readonly IAuctionAppService _auctionAppService;
        public BoothController(IBoothAppService boothAppService, ISellerAppService sellerAppService, IProductAppService productAppService, IProductBoothAppService productBoothAppService ,IAuctionAppService auctionAppService)
        {
            _boothAppService = boothAppService;
            _sellerAppService = sellerAppService;
            _productAppService = productAppService;
            _productBoothAppService = productBoothAppService;
            _auctionAppService = auctionAppService;

        }
        public async Task<IActionResult> Index(int id, CancellationToken cancellationToken)
        {
            var seller = await _sellerAppService.GetSellerById(id, cancellationToken);
            var booth = await _boothAppService.GetBoothBySeller(id, cancellationToken);
            var sellerview = new BoothViewModel
            {
                Id = booth.Id,
                HaveBooth = seller.HaveBooth,
                SellerId = seller.Id,
                Description = booth.Description,
                Medalname = booth.Medalname,
                Name = booth.Name,

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
                SellerId = boothView.SellerId,
                Description = boothView.Description,
                Name = boothView.Name,

            };
            await _boothAppService.Create(booth, cancellationToken);
            return RedirectToAction("Index", new { Id = boothView.Id });
        }

        public async Task<IActionResult> AddProduct(int id, int SellerId, CancellationToken cancellationToken)
        {
            var products = await _productAppService.GetAllConfirmedProduct(cancellationToken);
            var list = new ProductBoothViewModel()
            {

                BoothId = id,
                SellerId = SellerId,
                Products = products.Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
            };
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductBoothViewModel model, CancellationToken cancellationToken)
        {
            //var booth = await _boothAppService.Detail(model.BoothId,cancellationToken);
            //var products = await _productAppService.GetAll(cancellationToken);
            if (ModelState.IsValid)
            {
                var product = new ProductBoothDto()
                {
                    ProductName = model.ProductName,
                    BoothId = model.BoothId,
                    ProductId = model.ProductId,
                    NewPrice = model.NewPrice,
                    Count = model.Count,

                };
                await _productBoothAppService.Create(product, cancellationToken);
                return RedirectToAction("Index", new { Id = model.SellerId });
            }



            return View(model);

        }

        public async Task<IActionResult> AddAuction(int id, int SellerId, CancellationToken cancellationToken)
        {
            var products = await _productAppService.GetAllConfirmedProduct(cancellationToken);
            var list = new AuctionViewModel()
            {

                BoothId = id,
                SellerId = SellerId,
                Products = products.Select(p => new Product()
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToList(),
            };
            return View(list);
        }
        [HttpPost]
        public async Task<IActionResult> AddAuction(AuctionViewModel model, CancellationToken cancellationToken)
        {
            if(ModelState.IsValid)
            {
                var auction = new AuctionDto()
                {
                    
                    StartPrice = model.StartPrice,
                    StartTime = model.StartTime,
                    EndTime = model.EndTime,
                    ProductName = model.ProductName,
                    ProductId = model.ProductId,
                    BoothId=model.BoothId,
                };
                await _auctionAppService.Create(auction, cancellationToken);
                return RedirectToAction("Index", new { Id = model.SellerId });
            }

            return View(model);


        }
    }
}
