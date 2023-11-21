using Microsoft.AspNetCore.Http;
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
    public class ProductAppService : IProductAppService
    {
        private readonly IProductService _productService;
        public ProductAppService(IProductService productService)
        {
            _productService = productService;   
        }

        public async Task Confirm(int ProductId, CancellationToken cancellationToken)
        {
            await _productService.Confirm(ProductId, cancellationToken);
        }

        public async Task Create(ProductDto productDto, IFormFile file, CancellationToken cancellationToken)
        {
            await _productService.Create(productDto,file, cancellationToken);
        }

        public async Task<List<ProductDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _productService.GetAll(cancellationToken);
        }

        public Task<List<ProductDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllBySubCategoryId(int SubCategoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductDto> GetById(int id, CancellationToken cancellationToken)
        {
            return await _productService.GetById(id, cancellationToken);
        }

        public Task HardDelete(int ProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SoftDelete(int ProductId, CancellationToken cancellationToken)
        {
            await _productService.SoftDelete(ProductId, cancellationToken);
        }

        public async Task Update(ProductDto productDto, CancellationToken cancellationToken)
        {
            await _productService.Update(productDto, cancellationToken);
        }
    }
}
