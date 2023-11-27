using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public List<int> SubcategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; } = new List<SubCategory>();
    }
}
