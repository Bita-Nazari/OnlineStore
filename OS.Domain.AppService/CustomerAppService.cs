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
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        public CustomerAppService(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public Task<CustomerDto> Detail(int customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CustomerDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderDto>> GetCustomerOrders(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int customerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
