using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;


namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public ProductRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task Create(ProductDto productDto, CancellationToken cancellationToken)
        {

            var product = new Product()
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Description = productDto.Description,
                CreatedAt = DateTime.Now,
                BasePrice = productDto.Price,
                SubCategoryId = productDto.SubCategoryId,
                IsConfirmed = false,
                IsDeleted = false,
                IsAvailable = true
            };
            await _storeContext.Products.AddAsync(product);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var productList = await _storeContext.Products
                .Include(s => s.SubCategory)
                .Include(p => p.ProductPictures)
                .ThenInclude(n => n.Picture)

                .AsNoTracking()
                .Select(m => new ProductDto()
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    CreatedAt = m.CreatedAt,
                    Price = m.BasePrice,
                    SubcategoryName = m.SubCategory.Name,
                    Pictures = m.ProductPictures.Select(p => p.Picture).ToList()
                    ,
                    IsDeleted = m.IsDeleted,
                    IsConfirmed = m.IsConfirmed,



                }).ToListAsync(cancellationToken);
            return productList;
        }

        public Task<List<ProductDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HardDelete(int ProductId, CancellationToken cancellationToken)
        {
            var product = await _storeContext.Products
                .FirstOrDefaultAsync(p => p.Id == ProductId);
            _storeContext.Remove(product);
            await _storeContext.SaveChangesAsync(cancellationToken);

        }

        public async Task SoftDelete(int ProductId, CancellationToken cancellationToken)
        {
            var product = await _storeContext.Products
            .Where(p => p.Id == ProductId)
            .FirstOrDefaultAsync();
            product.IsDeleted = true;
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(ProductDto productDto, CancellationToken cancellationToken)
        {
            var product = await _storeContext.Products
            .Where(p => p.Id == productDto.Id)
            .Include(c => c.SubCategory)
            .FirstOrDefaultAsync();
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.BasePrice = productDto.Price;
                product.SubCategoryId = productDto.SubCategoryId;
                await _storeContext.SaveChangesAsync(cancellationToken);
            }
            try
            {
                await _storeContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exc)
            {

                throw;
            }


        }
        public async Task<ProductDto> GetById(int id, CancellationToken cancellationToken)
        {
            var product = await _storeContext.Products
                .Where(p => p.Id == id)
                .Include(c => c.SubCategory)
                .Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.BasePrice,
                    SubcategoryName = p.SubCategory.Name,
                    SubCategoryId = p.SubCategoryId


                })
                .FirstOrDefaultAsync();
            if (product == null)
            {
                throw new NullReferenceException();
            }
            return product;
        }

        public async Task Confirm(int ProductId, CancellationToken cancellationToken)
        {
            var product = await _storeContext.Products
.Where(p => p.Id == ProductId)
.FirstOrDefaultAsync();
            product.IsConfirmed = true;
            await _storeContext.SaveChangesAsync(cancellationToken);
        }
    }
}