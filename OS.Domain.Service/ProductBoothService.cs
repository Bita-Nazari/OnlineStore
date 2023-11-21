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
    public class ProductBoothService : IProductBoothService
    {
        private readonly IProductBoothRepository _productBoothRepository;
        public ProductBoothService(IProductBoothRepository productBoothRepository)
        {
            _productBoothRepository = productBoothRepository;
        }
        public async Task Create(ProductBoothDto product, CancellationToken cancellationToken)
        {
            await _productBoothRepository.Create(product, cancellationToken);
        }

        public Task<List<ProductBoothDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductBoothDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductBoothDto> GetById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int ProductBoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductBoothDto product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
