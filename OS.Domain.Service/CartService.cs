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
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        public Task Create(CartDto CartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<CartDto> Detail(int? CartId, CancellationToken cancellationToken)
        {
            return await _cartRepository.Detail(CartId, cancellationToken);
        }

        public Task<List<CartDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CartDto>> GetAllBoothCarts(int boothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int CartId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(int CartId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
