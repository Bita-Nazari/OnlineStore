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

        public async Task DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            await  _customerService.DeleteCustomer(id, cancellationToken);
           
        }

        public async  Task EditCustomer(AlluserDto user, CancellationToken cancellationToken)
        {
           await   _customerService.EditCustomer(user, cancellationToken);
            
        }

        public async Task<List<AlluserDto>> GetAllCustomers(CancellationToken cancellationToken)
        {
            return await _customerService.GetAllCustomers(cancellationToken);
        }

        public async Task<AlluserDto> GetCustomerById(int CustomerId, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerById(CustomerId, cancellationToken);
        }
    }
}
