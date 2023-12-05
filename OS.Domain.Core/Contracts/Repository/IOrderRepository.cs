using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface IOrderRepository
    {
        Task Create(int? CartId, CancellationToken cancellationToken);
        Task<List<OrderDto>>GetAll(CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllCustomerOrder(int customerId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken);
        Task<OrderDto> Detail(int orderId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllAuctionOrder(int customerId, CancellationToken cancellationToken);
        Task<OrderDto> DetailAuction(int orderId, CancellationToken cancellationToken);

    }
}
