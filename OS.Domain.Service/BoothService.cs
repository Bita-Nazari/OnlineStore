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
        public async Task Create(BoothDto boothDto, CancellationToken cancellationToken)
        {
           await _boothRepository.Create(boothDto, cancellationToken);
        }

        public async Task<BoothDto> Detail(int BoothId, CancellationToken cancellationToken)
        {
            return await _boothRepository.Detail(BoothId, cancellationToken);
        }

        public async Task<List<BoothDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _boothRepository.GetAll(cancellationToken);
        }

        public async Task<BoothDto> GetBoothBySeller(int sellerId, CancellationToken cancellationToken)
        {
            return await _boothRepository.GetBoothBySeller(sellerId, cancellationToken);
        }

        public Task HardDelete(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task SoftDelete(int BoothId, CancellationToken cancellationToken)
        {
            await _boothRepository.SoftDelete(BoothId, cancellationToken);
        }

        public async Task Update(BoothDto boothdto, CancellationToken cancellationToken)
        {
            await _boothRepository.Update(boothdto, cancellationToken);
        }

        public async Task UpdateMedal(int BoothId, CancellationToken cancellationToken)
        {
           await _boothRepository.UpdateMedal(BoothId, cancellationToken);
        }
    }
}
