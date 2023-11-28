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
    public class AuctionService : IAuctionService
    {
        private readonly IAuctionRepository _auctionRepository;
        public AuctionService(IAuctionRepository auctionRepository)
        {
            _auctionRepository = auctionRepository;
        }
        public async Task Create(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            await _auctionRepository.Create(auctionDto, cancellationToken);
        }

        public async Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _auctionRepository.GetAll(cancellationToken);
        }

        public async Task<List<AuctionDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            return await _auctionRepository.GetAllByBoothId(BoothId, cancellationToken);
        }

        public async Task<AuctionDto> GetDetail(int AuctionId, CancellationToken cancellationToken)
        {
            return await _auctionRepository.GetDetail(AuctionId, cancellationToken);
        }

        public Task Update(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
