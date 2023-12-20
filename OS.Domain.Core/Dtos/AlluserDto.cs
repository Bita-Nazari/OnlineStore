using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class AlluserDto
    {

        public int Id { get; set; }
        public int? ActiveCartId { get; set; }

        public string? FirstName { get; set; } 

        public string? LastName { get; set; }

        public string? PictureUrl { get; set; }

        public long? NationalCode { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? CityName { get; set; }
        public int? CityId { get; set; }
        public string ? Password { get; set; }
        public bool? HaveBooth { get; set; }

        public int? PictureId { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int? UserId { get; set; }

        public long? ShabaNumber { get; set; }

        public long? Wallet { get; set; }
       
        public string? Address { get; set; } = null!;

        public Customer? Customer { get; set; }
        public Seller? Seller { get; set; }
    }
}
