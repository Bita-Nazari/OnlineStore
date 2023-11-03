using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;


namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    internal class ProductRepository : IProductRepository
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
                BoothId = productDto.BoothId,
                Description = productDto.Description,
                CreatedAt = DateTime.Now,
                Price = productDto.Price,
                SubCategoryId = productDto.SubCategoryId,

            };
            await _storeContext.Products.AddAsync(product);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            var productList = await _storeContext.Products.AsNoTracking()
                .Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    BoothId = p.BoothId,
                    Description = p.Description,
                    CreatedAt = p.CreatedAt,
                    Price = p.Price,
                    SubCategoryId = p.SubCategoryId,



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
            .FirstOrDefaultAsync();
            if (product != null)
            {
                product.Name = productDto.Name;
                product.Description = productDto.Description;
                product.Price = productDto.Price;
                product.SubCategory = productDto.SubCategory;
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
    }
}
