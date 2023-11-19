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
        public async Task Create(BoothDto boothDto, CancellationToken cancellationToken)
        {
           await _boothService.Create(boothDto, cancellationToken);
        }

        public async Task<BoothDto> Detail(int BoothId, CancellationToken cancellationToken)
        {
            return await _boothService.Detail(BoothId, cancellationToken);
        }

        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _boothService.GetAll(cancellationToken);
        }

        public Task HardDelete(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SoftDelete(int BoothId, CancellationToken cancellationToken)
        {
            await _boothService.SoftDelete(BoothId, cancellationToken);
        }

        public async Task Update(BoothDto boothdto, CancellationToken cancellationToken)
        {
            await _boothService.Update(boothdto, cancellationToken);
        }
    }
}
