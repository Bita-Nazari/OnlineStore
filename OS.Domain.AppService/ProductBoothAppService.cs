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
    public class ProductBoothAppService : IProductBoothAppService
    {
        private readonly IProductBoothService _productBoothService;
        public ProductBoothAppService(IProductBoothService productBoothService)
        {
            _productBoothService = productBoothService;   
        }
        public async Task Create(ProductBoothDto product, CancellationToken cancellationToken)
        {
            await _productBoothService.Create(product, cancellationToken);
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
