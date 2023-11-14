using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class MedalDto
    {
        public int Id { get; set; }

        public int MedalTypeId { get; set; }

        public int Discount { get; set; }
        public string MedalName { get; set; }
    }
}
