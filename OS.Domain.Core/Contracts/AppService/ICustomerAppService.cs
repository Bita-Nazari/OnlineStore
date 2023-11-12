using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.AppService
{
    public interface ICustomerAppService
    {
        public Task<List<AlluserDto>> GetAllCustomers(CancellationToken cancellationToken);

        public Task<AlluserDto> GetCustomerById(int CustomerId, CancellationToken cancellationToken);

        public Task EditCustomer(AlluserDto user, CancellationToken cancellationToken);

        public Task DeleteCustomer(int id, CancellationToken cancellationToken);
    }

}