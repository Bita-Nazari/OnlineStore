using Microsoft.AspNetCore.Http;
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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task ChargeWallet(int Customerid, CustomerDto customerdto, CancellationToken cancellationToken)
        {
           await _customerRepository.ChargeWallet(Customerid, customerdto, cancellationToken);
        }

        public  async Task DeleteCustomer(int id, CancellationToken cancellationToken)
        {
           await  _customerRepository.DeleteCustomer(id, cancellationToken);
        }

        public  async Task EditCustomer(AlluserDto user, IFormFile file, CancellationToken cancellationToken)
        {
            await  _customerRepository.EditCustomer(user,file, cancellationToken);
        }

        public async Task<List<AlluserDto>> GetAllCustomers(CancellationToken cancellationToken)
        {
            return await _customerRepository.GetAllCustomers( cancellationToken);
        }

        public async Task<AlluserDto> GetCustomerById(int CustomerId, CancellationToken cancellationToken)
        {
            return await _customerRepository. GetCustomerById(CustomerId, cancellationToken);        
        }

        public async Task<AlluserDto> GetCustomerByUserId(int Userid, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByUserId(Userid, cancellationToken);
        }

        public async Task IsRestored(int id, CancellationToken cancellationToken)
        {
          await _customerRepository.IsRestored(id, cancellationToken);
        }
    }
}
