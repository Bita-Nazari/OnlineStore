using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Admin.Models;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using System.Threading;

namespace OnlineStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        public NewProductController(IProductAppService productAppService, ISubCategoryAppService subCategoryAppService)
        {
            _productAppService = productAppService;
            _subCategoryAppService = subCategoryAppService;
        }
        [HttpGet]
        public async  Task<IActionResult> Create( CancellationToken cancellationToken ) 
        {
            var subcategoriesdto = await _subCategoryAppService.GetAll(cancellationToken);
            var product = new ProductViewModel
            {
               
                subCategories = subcategoriesdto.Select(x => new SubCategory
                {
                    Id = x.Id,
                    Name = x.Name,

                }).ToList(),
            };


            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel ,IFormFile file, CancellationToken cancellationToken)
        {
            var subcategories = await _subCategoryAppService.GetAll(cancellationToken);

            var product = new ProductDto
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                SubCategoryId = productViewModel.SubCategoryId,
                Description = productViewModel.Description,
                SubcategoryName = productViewModel.SubcategoryName,


            };

            await _productAppService.Create(product, file, cancellationToken);
           return RedirectToAction("Product", "Product");
        }
    }
}
