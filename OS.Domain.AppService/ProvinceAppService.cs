using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class ProvinceAppService : IProvinceAppService
    {
        private readonly IProvinceService _provinceService;
        public ProvinceAppService(IProvinceService provinceService)
        {
            _provinceService = provinceService;  
        }
        public Task<List<ProvinceDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
