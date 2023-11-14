using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class ProductPictureRepository :IProductPictureRepository
    {
        public Task<List<ProductPictureDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();

        }
    }
}
