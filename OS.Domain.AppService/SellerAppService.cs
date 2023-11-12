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

        public  async Task DeleteSeller(int id, CancellationToken cancellationToken)
        {
           await  _sellerservice.DeleteSeller(id, cancellationToken);
        }

        public async Task EditSeller(AlluserDto user, CancellationToken cancellationToken)
        {
           await _sellerservice.EditSeller(user, cancellationToken);
        }

        public async Task<List<AlluserDto>> GetAllSellers(CancellationToken cancellationToken)
        {
            return await _sellerservice.GetAllSellers(cancellationToken);
        }

        public async Task<AlluserDto> GetSellerById(int SellerId, CancellationToken cancellationToken)
        {
           return await _sellerservice.GetSellerById(SellerId, cancellationToken);
        }
    }
}
