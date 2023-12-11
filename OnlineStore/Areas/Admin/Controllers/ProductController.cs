using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OS.Domain.AppService;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        public ProductController(IProductAppService productAppService, ISubCategoryAppService subCategoryAppService)
        {
            _productAppService = productAppService;
            _subCategoryAppService = subCategoryAppService;
        }
        public async Task<IActionResult> Product(CancellationToken cancellationToken)
        {
            var record = await _productAppService.GetAll(cancellationToken);
            var products = record.Select(r => new ProductViewModel
            {
                Id = r.Id,
                Name = r.Name,
                Price = r.Price,
                Description = r.Description,
                IsDeleted = r.IsDeleted,
                IsConfirmed = r.IsConfirmed,


            }).ToList();
            return View(products);
        }
        public async Task<IActionResult> Detail(int id, CancellationToken cancellationToken)
        {

            var record = await _productAppService.GetById(id, cancellationToken);
            var product = new ProductViewModel
            {
                Id = record.Id,
                Name = record.Name,
                Price = record.Price,
                Description = record.Description,
                SubcategoryName = record.SubcategoryName,
                pictures = record.Pictures
            };
            return View(product);

        }
        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var subcategories = await _subCategoryAppService.GetAll(cancellationToken);
            var record = await _productAppService.GetById(id, cancellationToken);
            var product = new ProductViewModel
            {
                Id = record.Id,
                Name = record.Name,
                Price = record.Price,
                SubCategoryId = record.SubCategoryId,
                Description = record.Description,
                SubcategoryName = record.SubcategoryName,
                subCategories = subcategories.Select(x => new SubCategory
                {
                    Id = x.Id,
                    Name = x.Name,

                }).ToList(),
            };
            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel product, CancellationToken cancellationToken)
        {
            var newProduct = new ProductDto()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Id = product.Id,
                SubCategoryId = product.SubCategoryId,

            };
            await _productAppService.Update(newProduct, cancellationToken);
            return RedirectToAction("Product");

        }
        
        public async Task<IActionResult> Confirm(int id, CancellationToken cancellationToken)
        {
            await _productAppService.Confirm(id, cancellationToken);
            return RedirectToAction("Product");
        }

        
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            await _productAppService.SoftDelete(id, cancellationToken);
            return RedirectToAction("Product");
        }

        public async Task<IActionResult> Restore(int id, CancellationToken cancellationToken)
        {
            await _productAppService.IsRestored(id, cancellationToken);
            return RedirectToAction("Product");
        }
    }
}
