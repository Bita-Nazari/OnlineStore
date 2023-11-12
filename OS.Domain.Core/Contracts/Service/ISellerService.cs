﻿using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface ISellerService
    {

        public Task<List<AlluserDto>> GetAllSellers(CancellationToken cancellationToken);

        public Task<AlluserDto> GetSellerById(int SellerId, CancellationToken cancellationToken);

        public Task EditSeller(AlluserDto user, CancellationToken cancellationToken);

        public Task  DeleteSeller(int id, CancellationToken cancellationToken);
    }
}
