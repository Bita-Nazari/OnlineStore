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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task Create(ProductDto productDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            return _productRepository.GetAll(cancellationToken);
        }

        public Task<List<ProductDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int ProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int ProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductDto productDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
