using Microsoft.AspNetCore.Mvc;
using OnlineStore.Areas.Seller.Models;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;

namespace OnlineStore.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class CreateProductController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IUserAppService _userAppService;
        private readonly ISellerAppService _sellerAppService;
        public CreateProductController(IProductAppService productAppService, ISubCategoryAppService subCategoryAppService ,IUserAppService userAppService , ISellerAppService sellerAppService)
        {
            _productAppService = productAppService;
            _subCategoryAppService = subCategoryAppService;
            _userAppService = userAppService;
            _sellerAppService = sellerAppService;
        }
        [HttpGet]
        public async Task<IActionResult> Create(int id ,CancellationToken cancellationToken)
        {
            var subcategoriesdto = await _subCategoryAppService.GetAll(cancellationToken);
            var product = new ProductViewModel
            {
                SellerId = id,

                subCategories = subcategoriesdto.Select(x => new SubCategory
                {
                    Id = x.Id,
                    Name = x.Name,

                }).ToList(),
            };


            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel productViewModel,IFormFile file ,CancellationToken cancellationToken)
        {
            var user  = await _userAppService.GetById(productViewModel.SellerId, cancellationToken);
            var subcategories = await _subCategoryAppService.GetAll(cancellationToken);

            var product = new ProductDto
            {
                //Id = productViewModel.Id,
                Name = productViewModel.Name,
                Price = productViewModel.Price,
                SubCategoryId = productViewModel.SubCategoryId,
                Description = productViewModel.Description,
                SubcategoryName = productViewModel.SubcategoryName,


            };

             await _productAppService.Create(product, file,cancellationToken);
            return RedirectToAction("Index", "Dashbord", new { Id = user.Id });
        }
    }
}

