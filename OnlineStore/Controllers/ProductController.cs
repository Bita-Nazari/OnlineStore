using Microsoft.AspNetCore.Mvc;
using OnlineStore.Models;
using OS.Domain.Core.Contracts.AppService;

namespace OnlineStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductBoothAppService _productBoothAppService;
        public ProductController(IProductBoothAppService productBoothAppService)
        {
            _productBoothAppService = productBoothAppService;
        }
        public async Task<IActionResult> GetAllByCategory(int id ,CancellationToken cancellationToken)
        {
            var products = await _productBoothAppService.GetAllBySubCategoryId(id, cancellationToken);
            var productView = products.Select(p => new ProductBoothViewModel()
            {
                Id = p.Id,
                BoothId = p.BoothId,
                BoothName = p.BoothName,
                Count = p.Count,
                Description = p.Description,
                NewPrice = p.NewPrice,
                ProductName = p.ProductName,
                SubcategoryId = p.SubcategoryId,
                SubcategoryName = p.SubcategoryName,
                Pictures = p.Pictures

            }).ToList();
            return View(productView);
        }
        public async Task<IActionResult> GetAllByBooth(int id, CancellationToken cancellationToken)
        {
            var products = await _productBoothAppService.GetAllByBoothId(id, cancellationToken);
            var productView = products.Select(p => new ProductBoothViewModel()
            {
                Id = p.Id,
                BoothId = p.BoothId,
                BoothName = p.BoothName,
                Count = p.Count,
                Description = p.Description,
                NewPrice = p.NewPrice,
                ProductName = p.ProductName,
                SubcategoryId = p.SubcategoryId,
                SubcategoryName = p.SubcategoryName,
                Pictures = p.Pictures

            }).ToList();
            return View(productView);


        }
        public async Task<IActionResult> Product(int id , CancellationToken cancellationToken)
        {
            var product = await _productBoothAppService.GetById(id, cancellationToken);
            var productView = new ProductBoothViewModel()
            {
                Id = product.Id,
                BoothName = product.BoothName,
                Count = product.Count,
                Description = product.Description,
                NewPrice = product.NewPrice,
                ProductName = product.ProductName,
                SubcategoryId = product.SubcategoryId,
                SubcategoryName = product.SubcategoryName,
                Pictures = product.Pictures

            };
            return View(productView);

        }

    }
}
