using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface IProductService
    {
        Task Create(ProductDto productDto, CancellationToken cancellationToken);
        Task HardDelete(int ProductId, CancellationToken cancellationToken);
        Task SoftDelete(int ProductId, CancellationToken cancellationToken);
        Task Update(ProductDto productDto, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAll(CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken);

    }
}
