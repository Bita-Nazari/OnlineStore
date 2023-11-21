﻿using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface IProductBoothService
    {
        Task Create(ProductBoothDto product, CancellationToken cancellationToken);
        Task SoftDelete(int ProductBoothId, CancellationToken cancellationToken);
        Task Update(ProductBoothDto product, CancellationToken cancellationToken);
        Task<List<ProductBoothDto>> GetAll(CancellationToken cancellationToken);
        Task<List<ProductBoothDto>> GetAllByBoothId(int BoothId, CancellationToken cancellationToken);
        public Task<ProductBoothDto> GetById(int id, CancellationToken cancellationToken);
    }
}
