using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface IOrderService
    {
        Task Create(OrderDto orderDto);
        Task HardDelete(int OrderId, CancellationToken cancellationToken);
        Task SoftDelete(int OrderId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllCustomerOrder(int customerId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken);
        Task Detail(int orderId, CancellationToken cancellationToken);
    }
}
