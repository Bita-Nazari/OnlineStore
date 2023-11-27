using Microsoft.AspNetCore.Mvc;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Entities;
using System.Threading.Tasks;

namespace OnlineStore.Controllers
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryViewComponent(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }
        public IViewComponentResult Invoke(CancellationToken cancellationToken)
        {
            var categories = Task.Run(() => _categoryAppService.GetAll(cancellationToken)).Result;
            var viewcategories = categories.Select(c => new CategoryVM()
            {
                Id = c.Id,
                Name = c.Name,
                SubCategories = c.SubCategories,
                
            }).ToList();

            return View("Default", viewcategories);
        }

        public class CategoryVM
        {
            public int Id { get; set; }

            public string Name { get; set; } = null!;
            public int SubcategoryId { get; set; }

            public bool IsDeleted { get; set; }
            public List<SubCategory>? SubCategories { get; set; }

        }

    }
}
