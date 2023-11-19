using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BoothController : Controller
    {
        private readonly IBoothAppService _boothAppService;
        private readonly IMedalAppService _medalAppService;

        public BoothController(IBoothAppService boothAppService, IMedalAppService medalAppService)
        {
            _boothAppService = boothAppService;
            _medalAppService = medalAppService;
        }
        public async Task<IActionResult> Booth(CancellationToken cancellationToken)
        {
            var booths = await _boothAppService.GetAll(cancellationToken);
            var boothViewmodel = booths.Select(x => new BoothViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Medalname = x.Medalname,
                SellerName = x.SellerName,
                IsDeleted = x.IsDeleted,
                Products = x.Products,
            }).ToList();
            return View(boothViewmodel);
        }
        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {
            var booth = await _boothAppService.Detail(id, cancellationToken);
            var boothviewmodel = new BoothViewModel
            {
                Id = booth.Id,
                Name = booth.Name,
                Medalname = booth.Medalname,
                SellerName = booth.SellerName,
                Description = booth.Description,
                Products = booth.Products,
            };
            return View(boothviewmodel);
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var booth = await _boothAppService.Detail(id, cancellationToken);
            var medals = await _medalAppService.GetAll(cancellationToken);
            var boothview = new BoothViewModel
            {
                Id = booth.Id,
                MedalId = booth.MedalId,
                Name = booth.Name,
                Description = booth.Description,
            };
            return View(boothview);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(BoothViewModel boothView, CancellationToken cancellationToken)
        {
            var booth = new BoothDto
            {
                Description = boothView.Description,
                Name = boothView.Name,
                Id = boothView.Id,
            };
            await _boothAppService.Update(booth, cancellationToken);
            return RedirectToAction("Booth");


        }
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _boothAppService.SoftDelete(id, cancellationToken);
            return RedirectToAction("Booth");
        }
    }
}
