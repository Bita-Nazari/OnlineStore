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
    public class CityAppService : ICityAppService
    {
        private readonly ICityService _cityService;
        public CityAppService(ICityService cityService)
        {
            _cityService = cityService;
        }
        public Task<List<CityDto>> GetAll(CancellationToken cancellationToken)
        {
            return _cityService.GetAll(cancellationToken);
        }
    }
}
