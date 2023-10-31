using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface ICustomerRepository
    {
  
        Task HardDelete(int customerId, CancellationToken cancellationToken);
        Task Update(int customerId, CancellationToken cancellationToken);
        Task<List<CustomerDto>> GetAll(CancellationToken cancellationToken);
        Task<CustomerDto> Detail(int customerId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetCustomerOrders(int productId, CancellationToken cancellationToken);
    }
}
