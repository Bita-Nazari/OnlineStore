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
    public class SellerAppService : ISellerAppService
    {
        private readonly ISellerService _sellerservice;
        public SellerAppService(ISellerService sellerService)
        {
            _sellerservice= sellerService;
        }
        public Task<List<SellerDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SellerDto> GetDetail(int SellerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int SellerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int SellerId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(SellerDto sellerDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
