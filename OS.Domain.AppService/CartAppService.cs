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
    public class CartAppService :ICartAppService
    {
        private readonly ICartService _cartService;
        public CartAppService(ICartService cartService) 
        {
        _cartService = cartService;
        }

        public Task Create(CartDto CartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<CartDto> Detail(int CartId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
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
