using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class ProvinceDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
