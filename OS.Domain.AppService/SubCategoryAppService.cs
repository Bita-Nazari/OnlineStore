using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class SubCategoryAppService : ISubCategoryAppService
    {
        private readonly ISubCategoryService _subCategoryService;
        public SubCategoryAppService(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
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
