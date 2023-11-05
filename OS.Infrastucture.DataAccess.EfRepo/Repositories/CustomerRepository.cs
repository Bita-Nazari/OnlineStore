using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public CustomerRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task<CustomerDto> Detail(int customerId, CancellationToken cancellationToken)
        {
            var customer = await _storeContext.Customers
                .Where(c=>c.Id== customerId)
                .FirstOrDefaultAsync(cancellationToken);
            var customerDto = new CustomerDto()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                CityId = customer.CityId,
                PictureId = customer.PictureId,

            };
            return customerDto;

        }

        public async Task<List<CustomerDto>> GetAll(CancellationToken cancellationToken)
        {
            var customerList = await _storeContext.Customers.AsNoTracking()
                .Select(c => new CustomerDto()
                {
                    Id= c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Address = c.Address,
                    CityId = c.CityId,
                    PictureId = c.PictureId,

                }).ToListAsync(cancellationToken);
            return customerList;
        }

        public Task<List<OrderDto>> GetCustomerOrders(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HardDelete(int customerId, CancellationToken cancellationToken)
        {
            var customer = await _storeContext.Customers
                .Where(c=> c.Id == customerId)
                .FirstOrDefaultAsync();
            _storeContext.Customers.Remove(customer);
            await _storeContext.SaveChangesAsync(cancellationToken);

            
        }

        public async Task Update(CustomerDto customerDto, CancellationToken cancellationToken)
        {
            var customer = await _storeContext.Customers
              .Where(c => c.Id == customerDto.Id)
              .FirstOrDefaultAsync();
            if(customer != null)
            {
                customer.Address= customerDto.Address;
                customer.CityId= customerDto.CityId;
                customer.PictureId= customerDto.PictureId;
                customer.FirstName= customerDto.FirstName;
                customer.LastName= customerDto.LastName;
            }
            await _storeContext.SaveChangesAsync(cancellationToken);
        }
    }
}
