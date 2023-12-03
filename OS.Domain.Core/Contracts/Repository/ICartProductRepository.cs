﻿using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface ICartProductRepository
    {
        Task<List<CartProductDto>> GetAllProduct(CartProductDto cartDto, CancellationToken cancellationToken);
        Task AddProduct(int CustomerId, int ProductId, CancellationToken cancellationToken);
    }
}
