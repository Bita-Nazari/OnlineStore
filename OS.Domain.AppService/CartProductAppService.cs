using OS.Domain.Core.Contracts.AppService;
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
        public Task<List<CartProductDto>> GetAllProduct(CartProductDto cartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
