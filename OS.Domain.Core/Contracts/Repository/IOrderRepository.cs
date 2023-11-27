﻿using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface IOrderRepository
    {
        Task Create(OrderDto orderDto, CancellationToken cancellationToken);
        Task<List<OrderDto>>GetAll(CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllCustomerOrder(int customerId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken);
        
    }
}
