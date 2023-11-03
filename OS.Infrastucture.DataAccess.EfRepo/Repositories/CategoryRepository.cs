using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public CategoryRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task Create(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var Category = new Category()
            {
                Id  = categoryDto.Id,
                Name = categoryDto.Name,
               

            };
            await _storeContext.Categories.AddAsync(Category);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            var CategoryList =await _storeContext.Categories.AsNoTracking()
                .Select(c => new CategoryDto()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync(cancellationToken);
            return CategoryList;
        }

        public async Task HardDelete(int categoryId, CancellationToken cancellationToken)
        {
            var category = await _storeContext.Categories
                .Where(c => c.Id == categoryId)
                .FirstOrDefaultAsync();
            _storeContext.Categories.Remove(category);
            await _storeContext.SaveChangesAsync(cancellationToken);

        }

        public  async Task SoftDelete(int categoryId, CancellationToken cancellationToken)
        {
            var category = await _storeContext.Categories
             .Where(c => c.Id == categoryId)
             .FirstOrDefaultAsync();
            category.IsDeleted= true;
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = await _storeContext.Categories
            .Where(c => c.Id == categoryDto.Id)
            .FirstOrDefaultAsync();
            if(category != null)
            {
                category.Name = categoryDto.Name;

            }
            await _storeContext.SaveChangesAsync();
        }
    }
}
