using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class CartProductRepository : ICartProductRepository
    {
        private readonly OnlineStoreContext _storeContext;
        private readonly ICustomerRepository _customerRepository;
        public CartProductRepository(OnlineStoreContext storeContext, ICustomerRepository customerRepository)
        {
            _storeContext = storeContext;
            _customerRepository = customerRepository;
        }

        public async Task AddProduct(int UserId, int ProductId, CancellationToken cancellationToken)
        {

            var customer =  await _customerRepository.GetCustomerByUserId(UserId, cancellationToken);
            var product = await _storeContext.ProductBooths.Where(p=>p.Id== ProductId).FirstOrDefaultAsync();
            var productCart = new ProductCart
            {
                ProductBoothId = product.Id,
                CartId = customer.ActiveCartId
            };
           await _storeContext.ProductCarts.AddAsync(productCart);
            _storeContext.SaveChanges();
           
        }

        public async Task DeleteProduct(int? CartId, int ProductId, CancellationToken cancellationToken)
        {
            var product = await _storeContext.ProductCarts
                .Where(c=> c.CartId==CartId && c.ProductBoothId==ProductId)
                .FirstOrDefaultAsync();
             _storeContext.ProductCarts.Remove(product);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public Task<List<CartProductDto>> GetAllProduct(CartProductDto cartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
