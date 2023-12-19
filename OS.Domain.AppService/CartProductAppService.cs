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
    public class CartProductAppService : ICartProductAppService
    {
        private readonly ICartProductService _CartproductService;

        public CartProductAppService(ICartProductService CartproductService)
        {
            _CartproductService = CartproductService;
        }

        public async Task AddProduct(int CustomerId, int ProductId, CancellationToken cancellationToken)
        {
            await _CartproductService.AddProduct(CustomerId, ProductId, cancellationToken);
        }

        public async Task DeleteProduct(int? CartId, int ProductId, CancellationToken cancellationToken)
        {
           await _CartproductService.DeleteProduct(CartId, ProductId, cancellationToken);
        }

        public Task<List<CartProductDto>> GetAllProduct(CartProductDto cartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
