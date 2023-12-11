using Microsoft.AspNetCore.Http;
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

        public async Task Confirm(int ProductId, CancellationToken cancellationToken)
        {
           await _productRepository.Confirm(ProductId, cancellationToken);
        }

        public async Task Create(ProductDto productDto, IFormFile file,CancellationToken cancellationToken)
        {
            await _productRepository.Create(productDto, file, cancellationToken);
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _productRepository.GetAll(cancellationToken);
        }

        public Task<List<ProductDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllConfirmedProduct(CancellationToken cancellationToken)
        {
            return await _productRepository.GetAllConfirmedProduct(cancellationToken);
        }

        public async Task<ProductDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _productRepository.GetById(id, cancellationToken);
        }

        public Task HardDelete(int ProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task IsRestored(int id, CancellationToken cancellationToken)
        {
            await _productRepository.IsRestored(id, cancellationToken);
        }

        public async Task SoftDelete(int ProductId, CancellationToken cancellationToken)
        {
           await _productRepository.SoftDelete(ProductId, cancellationToken);
        }

        public async Task Update(ProductDto productDto, CancellationToken cancellationToken)
        {
            await _productRepository.Update(productDto, cancellationToken);
        }
    }
}
