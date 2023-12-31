﻿using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        public CategoryAppService(ICategoryService categoryService)
        {
            _categoryService = categoryService;   
        }
        public Task Create(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryDto>> GetAll(CancellationToken cancellationToken)
        {
            return await _categoryService.GetAll(cancellationToken);
        }

        public List<CategoryDto> GetAllCategory()
        {
            return _categoryService.GetAllCategory();
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
