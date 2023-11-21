using Microsoft.AspNetCore.Hosting;
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
    public class ProductBoothRepository : IProductBoothRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public ProductBoothRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
           
        }
        public async Task Create(ProductBoothDto product, CancellationToken cancellationToken)
        {

            var Newproduct = new ProductBooth()
            {
                NewPrice = product.NewPrice,
                ProductId = product.ProductId,
                BoothId = product.BoothId,
                Count = product.Count,
                


            };
            await _storeContext.ProductBooths.AddAsync(Newproduct);
            await _storeContext.SaveChangesAsync(cancellationToken);
        }

        public Task<List<ProductBoothDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductBoothDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductBoothDto> GetById(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int ProductBoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(ProductBoothDto product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
