﻿using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Task Create(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int categoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task SoftDelete(int categoryId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}