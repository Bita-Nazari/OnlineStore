using Microsoft.AspNetCore.Http;
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
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository; 
        }

        public  async Task DeleteSeller(int id, CancellationToken cancellationToken)
        {
            await  _sellerRepository.DeleteSeller(id, cancellationToken);
        }

        public  async Task EditSeller(AlluserDto user, IFormFile file, CancellationToken cancellationToken)
        {
           await  _sellerRepository.EditSeller(user, file, cancellationToken);
        }

        public async Task<List<AlluserDto>> GetAllSellers(CancellationToken cancellationToken)
        {
            return await _sellerRepository.GetAllSellers(cancellationToken);
        }

        public async Task<AlluserDto> GetSellerById(int SellerId, CancellationToken cancellationToken)
        {
            return await _sellerRepository.GetSellerById(SellerId, cancellationToken);
        }

        public async Task IsRestored(int id, CancellationToken cancellationToken)
        {
           await _sellerRepository.IsRestored(id, cancellationToken);
        }
    }
}
