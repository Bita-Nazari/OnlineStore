using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface ICartRepository
    {
        Task Create(CartDto CartDto, CancellationToken cancellationToken);
        Task HardDelete(int CartId, CancellationToken cancellationToken);
        Task Update(int CartId, CancellationToken cancellationToken);
        Task<CartDto> Detail(int CartId, CancellationToken cancellationToken);
        Task<List<CartDto>> GetAll(CancellationToken cancellationToken);
        Task<List<CartDto>> GetAllBoothCarts(int boothId, CancellationToken cancellationToken);
        Task<List<ProductDto>> GetAllProduct(int cartId, CancellationToken cancellationToken);
    }
}
