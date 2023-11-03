using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class BoothAppService : IBoothAppService
    {
        private readonly IBoothService _boothService;

        public BoothAppService(IBoothService boothService)
        {
            _boothService   = boothService;
        }
        public Task Create(BoothDto boothDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BoothDto> Detail(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(BoothDto boothdto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
