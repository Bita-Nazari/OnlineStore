using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class ProductBoothRepository : IProductBoothRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public ProductBoothRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;

        }
        public async Task Create(ProductBoothDto product, CancellationToken cancellationToken)
        {

            var Newproduct = new ProductBooth()
            {
                NewPrice = product.NewPrice,
                ProductId = product.ProductId,
                BoothId = product.BoothId,
                Count = product.Count,



            };
            await _storeContext.ProductBooths.AddAsync(Newproduct);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductBoothDto>> GetAll(CancellationToken cancellationToken)
        {
            var products = await _storeContext.ProductBooths
        .Include(p => p.Product)
        .ThenInclude(n => n.ProductPictures)
        .ThenInclude(s => s.Picture)
        .Include(p => p.Product)
        .ThenInclude(s => s.SubCategory)
        .Include(b => b.booth)
        .Select(m => new ProductBoothDto()
        {
            Id = m.Id,
            ProductName = m.Product.Name,
            Description = m.Product.Description,
            Pictures = m.Product.ProductPictures.Select(p => p.Picture).ToList(),
            SubcategoryName = m.Product.SubCategory.Name,
            SubcategoryId = m.Product.SubCategory.Id,
            NewPrice = m.NewPrice,
            BoothName = m.booth.Name,
            BoothId = m.booth.Id,
            Count = m.Count,
            ProductId = m.Product.Id,

        }).ToListAsync();
            return products;
        }

        public async Task<List<ProductBoothDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            var products = await _storeContext.ProductBooths
         .Where(p => p.BoothId == BoothId)
         .Include(p => p.Product)
         .ThenInclude(n => n.ProductPictures)
         .ThenInclude(s => s.Picture)
         .Include(p => p.Product)
         .ThenInclude(s => s.SubCategory)
         .Include(b => b.booth)
         .Select(m => new ProductBoothDto()
         {
         Id = m.Id,
         ProductName = m.Product.Name,
         Description = m.Product.Description,
         Pictures = m.Product.ProductPictures.Select(p => p.Picture).ToList(),
         SubcategoryName = m.Product.SubCategory.Name,
         SubcategoryId = m.Product.SubCategory.Id,
         NewPrice = m.NewPrice,
         BoothName = m.booth.Name,
         BoothId = m.booth.Id,
         Count = m.Count,
         ProductId = m.Product.Id,

          }).ToListAsync();
            return products;
        }
        public async Task<List<ProductBoothDto>> GetAllBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            var products = await _storeContext.ProductBooths
                .Where(p => p.Product.SubCategoryId == SubCategoryId)
                .Include(p => p.Product)
                .ThenInclude(n => n.ProductPictures)
                .ThenInclude(s => s.Picture)
                .Include(p => p.Product)
                .ThenInclude(s => s.SubCategory)
                .Include(b => b.booth)
                .Select(m => new ProductBoothDto()
                {
                    Id = m.Id,
                    ProductName = m.Product.Name,
                    Description = m.Product.Description,
                    Pictures = m.Product.ProductPictures.Select(p => p.Picture).ToList(),
                    SubcategoryName = m.Product.SubCategory.Name,
                    SubcategoryId = m.Product.SubCategory.Id,
                    NewPrice = m.NewPrice,
                    BoothName = m.booth.Name,
                    BoothId = m.booth.Id,
                    Count = m.Count,
                    ProductId = m.Product.Id,

                }).ToListAsync();
            return products;

        }
        public async Task<ProductBoothDto> GetById(int id, CancellationToken cancellationToken)
        {
            var product = await _storeContext.ProductBooths
               .Where(p => p.Id == id)
               .Include(p => p.Product)
               .ThenInclude(n => n.ProductPictures)
               .ThenInclude(s => s.Picture)
               .Include(p => p.Product)
               .ThenInclude(s => s.SubCategory)
               .Include(b => b.booth)
               .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new NullReferenceException();
            }
            var productDto = new ProductBoothDto()
            {
                Id = product.Id,
                ProductName = product.Product.Name,
                Description = product.Product.Description,
                Pictures = product.Product.ProductPictures.Select(p => p.Picture).ToList(),
                SubcategoryName = product.Product.SubCategory.Name,
                SubcategoryId = product.Product.SubCategory.Id,
                NewPrice = product  .NewPrice,
                BoothName = product.booth.Name,
                BoothId =   product.booth.Id,
                Count = product.Count,
                ProductId = product.Product.Id,

            };
            return productDto;
        }

        public Task SoftDelete(int ProductBoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductBoothDto product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
