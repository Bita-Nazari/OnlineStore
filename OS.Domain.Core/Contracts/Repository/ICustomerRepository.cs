﻿using Microsoft.AspNetCore.Http;
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

        public Task<List<AlluserDto>> GetAllCustomers(CancellationToken cancellationToken);

        public Task<AlluserDto> GetCustomerById(int CustomerId, CancellationToken cancellationToken);
        public Task<AlluserDto> GetCustomerByUserId(int Userid, CancellationToken cancellationToken);

        public Task EditCustomer(AlluserDto user, IFormFile file, CancellationToken cancellationToken);

        public Task DeleteCustomer(int id, CancellationToken cancellationToken);
        public Task ChargeWallet(int Customerid, CustomerDto customerdto, CancellationToken cancellationToken);
        public Task IsRestored(int id, CancellationToken cancellationToken);
    }
}
