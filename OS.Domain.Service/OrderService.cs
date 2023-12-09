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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task Create(int? CartId, CancellationToken cancellationToken)
        {
            await _orderRepository.Create(CartId, cancellationToken);
        }

        public async Task<OrderDto> Detail(int orderId, CancellationToken cancellationToken)
        {
            return await _orderRepository.Detail(orderId, cancellationToken);
        }

        public async Task<OrderDto> DetailAuction(int orderId, CancellationToken cancellationToken)
        {
            return await _orderRepository.DetailAuction(orderId, cancellationToken);
        }

        public Task<List<OrderDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetAllAuctionOrder(int customerId, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllAuctionOrder(customerId, cancellationToken);
        }

        public Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDto>> GetAllCommessionOrders(CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllCommessionOrders(cancellationToken);
        }

        public async Task<List<OrderDto>> GetAllCustomerOrder(int customerId, CancellationToken cancellationToken)
        {
           return await _orderRepository.GetAllCustomerOrder(customerId, cancellationToken);    
        }

        public Task HardDelete(int OrderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int OrderId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
