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
    public class SubCategoryRepository :ISubCategoryRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public SubCategoryRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task Create(SubcategoryDto subcategoryDto, CancellationToken cancellationToken)
        {
            var Subcategory = new SubCategory()
            {
                Id = subcategoryDto.Id,
                Name = subcategoryDto.Name,
                CategoryId = subcategoryDto.CategoryId,
            };
            await _storeContext.SubCategories.AddAsync(Subcategory);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<SubcategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            var subcategoryList = await _storeContext.SubCategories
                .AsNoTracking()
                .Select(c => new SubcategoryDto()
            {
                Id = c.Id,
                Name = c.Name,
                CategoryId = c.CategoryId,

            }).ToListAsync(cancellationToken);
            return subcategoryList;

        }

        public async Task HardDelete(int subcategoryId, CancellationToken cancellationToken)
        {
            var subcategory = await _storeContext.SubCategories
                .Where(s => s.Id == subcategoryId)
                .FirstOrDefaultAsync();
            _storeContext.SubCategories.Remove(subcategory);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task SoftDelete(int subcategoryId, CancellationToken cancellationToken)
        {
            var subcategory = await _storeContext.SubCategories
            .Where(s => s.Id == subcategoryId)
            .FirstOrDefaultAsync();
            subcategory.IsDeleted= true;
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public async Task Update(SubcategoryDto subcategoryDto, CancellationToken cancellationToken)
        {
            var subcategory = await _storeContext.SubCategories
            .Where(s => s.Id == subcategoryDto.Id)
            .FirstOrDefaultAsync();
            if (subcategory != null)
            {
                subcategory.CategoryId = subcategoryDto.Id;
                subcategory.Name = subcategoryDto.Name;
            }
            await _storeContext.SaveChangesAsync(cancellationToken);

        }
    }
}
