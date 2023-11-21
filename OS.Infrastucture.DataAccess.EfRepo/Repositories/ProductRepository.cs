using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ProductRepository(OnlineStoreContext storeContext, IWebHostEnvironment hostingEnvironment)
        {
            _storeContext = storeContext;
            _hostingEnvironment = hostingEnvironment;
        }
        public async Task Create(ProductDto productDto, IFormFile file,CancellationToken cancellationToken)
        {

            var product = new Product()
            {
                //Id = productDto.Id,
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
            await _storeContext.SaveChangesAsync();
            if (file != null && file.Length > 0)
            {
                // Generate a unique file name
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                var picture = new Picture
                {
                   
                    Url = "/upload/" + uniqueFileName, // Adjust the path as needed
                    IsDeleted = false,
                    IsConfirmed = false,
                    IsProfilePicture = false // You might need to set this based on your requirements


                };
                await _storeContext.Pictures.AddAsync(picture);
                await _storeContext.SaveChangesAsync();
                var productPicture = new ProductPicture
                {
                    ProductId = product.Id,
                    PictureId = picture.Id
                };
                await _storeContext.ProductPictures.AddAsync(productPicture);
                await _storeContext.SaveChangesAsync(cancellationToken);
                var webRootPath = _hostingEnvironment.WebRootPath;

                // Combine with the upload folder path
                var uploadPath = Path.Combine(webRootPath, "upload");

                // Save the file to the server with the unique name
                var filePath = Path.Combine(uploadPath, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream, cancellationToken);
                }

            }
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