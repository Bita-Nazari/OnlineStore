using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface ICategoryService
    {
        Task Create(CategoryDto categoryDto, CancellationToken cancellationToken);
        Task HardDelete(int categoryId, CancellationToken cancellationToken);
        Task SoftDelete(int categoryId, CancellationToken cancellationToken);
        Task Update(int CategoryId, CancellationToken cancellationToken);
        Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken);
    }
}
