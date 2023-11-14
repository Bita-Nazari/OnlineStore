using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class ProductPictureAppService : IProductPictureAppService
    {
        public Task<List<ProductPictureDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
