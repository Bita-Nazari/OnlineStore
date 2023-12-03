using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface ICartProductService
    {
        Task<List<CartProductDto>> GetAllProduct(CartProductDto cartDto, CancellationToken cancellationToken);
        Task AddProduct(int CustomerId, int ProductId, CancellationToken cancellationToken);
    }
}
