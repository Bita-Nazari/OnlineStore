using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
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

        public async Task<List<ProductBoothDto>> GetAll(CancellationToken cancellationToken)
        {
           return await _productBoothRepository.GetAll(cancellationToken);
        }

        public async Task<List<ProductBoothDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
           return await _productBoothRepository.GetAllByBoothId(BoothId, cancellationToken);
        }

        public async Task<List<ProductBoothDto>> GetAllBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            return await _productBoothRepository.GetAllBySubCategoryId(SubCategoryId, cancellationToken);
        }

        public async Task<ProductBoothDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _productBoothRepository.GetById(id, cancellationToken);
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
