using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Service
{
    public class BoothService : IBoothService
    {
        private readonly IBoothRepository _boothRepository;
        public BoothService(IBoothRepository boothRepository)
        {
            _boothRepository = boothRepository;
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
