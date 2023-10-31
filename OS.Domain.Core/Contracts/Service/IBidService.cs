using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface IBidService
    {
        Task Create(BidDto bid, CancellationToken cancellationToken);
        Task SoftDelete(int bidId, CancellationToken cancellationToken);
        Task HardDelete(int bidId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetAll(CancellationToken cancellationToken);
        Task<List<BidDto>> GetAllProductBid(int ProductId, CancellationToken cancellationToken);
        Task<List<BidDto>> GetAllCustomerBid(int CustomerId, CancellationToken cancellationToken);
        Task<BidDto> GetDetail(int bidId, CancellationToken cancellationToken);
    }
}
