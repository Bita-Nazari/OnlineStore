using OS.Domain.Core.Contracts.AppService;
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
    public class CartProductService : ICartProductService
    {
        private readonly ICartProductRepository _cartProductRepository;
        public CartProductService(ICartProductRepository cartProductRepository)
        {
            _cartProductRepository = cartProductRepository;   
        }
        public async Task AddProduct(int CustomerId, int ProductId, CancellationToken cancellationToken)
        {
            await _cartProductRepository.AddProduct(CustomerId, ProductId, cancellationToken);
        }

        public async Task DeleteProduct(int? CartId, int ProductId, CancellationToken cancellationToken)
        {
            await _cartProductRepository.DeleteProduct(CartId, ProductId, cancellationToken);   
        }

        public Task<List<CartProductDto>> GetAllProduct(CartProductDto cartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
