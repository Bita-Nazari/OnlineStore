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
    public class AuctionAppService : IAuctionAppService
    {
        private readonly IAuctionService _auctionService;
        public AuctionAppService(IAuctionService auctionservice)
        {
            _auctionService = auctionservice;
        }
        public async Task Create(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            await _auctionService.Create(auctionDto, cancellationToken);
        }

        public Task<List<AuctionDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<AuctionDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionDto> GetDetail(int AuctionId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(AuctionDto auctionDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
