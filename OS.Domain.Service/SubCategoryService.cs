using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Service
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }
        public Task Create(SubcategoryDto subcategoryDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<SubcategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int subcategoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int subcategoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(SubcategoryDto subcategoryDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
