using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;

namespace OnlineStore.Controllers
{
    public class BoothController : Controller
    {
        private readonly IBoothAppService _boothAppService;
        public BoothController(IBoothAppService boothAppService)
        {
            _boothAppService = boothAppService;
        }
        public async Task<IActionResult> GetAllBooth(CancellationToken cancellationToken)
        {
            var booths = await _boothAppService.GetAll(cancellationToken);

            var boothview= booths.Select(c=> new BoothViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Medalname = c.Medalname,
                TotalCount = c.TotalCount,
            }).ToList();
            return View(boothview);
        }

 
    }
}
