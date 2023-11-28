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
    public class BidAppService : IBidAppService
    { 
        private readonly IBidService _bidService;
        public BidAppService(IBidService bidService)
        {
            _bidService = bidService;
        }
        public async Task Create(BidDto bid, CancellationToken cancellationToken)
        {
            await _bidService.Create(bid, cancellationToken);
        }

        public Task<List<BidDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BidDto>> GetAllCustomerBid(int CustomerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<BidDto>> GetAllProductBid(int ProductId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<BidDto> GetDetail(int bidId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int bidId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int bidId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
