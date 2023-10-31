using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface ISubCategoryRepository
    {
        Task Create(SubcategoryDto subcategoryDto, CancellationToken cancellationToken);
        Task HardDelete(int subcategoryId, CancellationToken cancellationToken);
        Task SoftDelete(int subcategoryId, CancellationToken cancellationToken);
        Task Update(int subcategoryId, CancellationToken cancellationToken);
        Task<List<SubcategoryDto>> GetAll(CancellationToken cancellationToken);
    }
}
