﻿using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface ICartService
    {
        Task Create(int CustomerId, CancellationToken cancellationToken);
        Task HardDelete(int CartId, CancellationToken cancellationToken);
        Task Update(int CartId, CancellationToken cancellationToken);
        Task<CartDto> Detail(int? CartId, CancellationToken cancellationToken);
        Task<List<CartDto>> GetAll(CancellationToken cancellationToken);
        Task<List<CartDto>> GetAllBoothCarts(int boothId, CancellationToken cancellationToken);
        
    }
}
