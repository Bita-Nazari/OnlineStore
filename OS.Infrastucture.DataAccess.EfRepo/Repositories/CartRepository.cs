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

    public class CartRepository : ICartRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public CartRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task Create(CartDto CartDto, CancellationToken cancellationToken)
        {
            var Cart = new Cart()
            {
                CustomerId = CartDto.CustomerId,
                CreatedAt = DateTime.Now,
                BoothId = CartDto.BoothId,
                Id = CartDto.Id,
            };
            await _storeContext.Carts.AddAsync(Cart);
            await _storeContext.SaveChangesAsync(cancellationToken);
            
        }

        public async Task<CartDto> Detail(int CartId, CancellationToken cancellationToken)
        {
            var cart = await _storeContext.Carts
                .Where(c=> c.Id == CartId)
                .FirstOrDefaultAsync(cancellationToken);
            var cartDto = new CartDto()
            {
                CustomerId = cart.CustomerId,
                CreatedAt = cart.CreatedAt,
                BoothId = cart.BoothId

            };
            return cartDto;
        }

        public async Task<List<CartDto>> GetAll(CancellationToken cancellationToken)
        {
            var CartList = await _storeContext.Carts
                .AsNoTracking()
                .Select(c=> new CartDto()
            {
                CustomerId = c.CustomerId,
                CreatedAt= c.CreatedAt,
                BoothId = c.BoothId
            }).ToListAsync(cancellationToken);
            return CartList;
        }

        public Task<List<CartDto>> GetAllBoothCarts(int boothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> GetAllProduct(int cartId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductDto>> GetAllProduct(CartDto cartDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task HardDelete(int CartId, CancellationToken cancellationToken)
        {
            var cart  = await _storeContext.Carts.Where(c=> c.Id == CartId).FirstOrDefaultAsync();
            _storeContext.Remove(cart);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public Task Update(int CartId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
