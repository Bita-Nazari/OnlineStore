
using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber{ get; set; }
        public string? MedalName { get; set; }
        public string? ConfirmPassword { get; set; }
        public int? SellerId { get; set; }
        public int? CustomerId { get; set; }
        public string? Role { get; set; }
        public bool IsSeller { get; set; }
        public List<string> Roles { get; set; }
        public Customer? Customer { get; set; }
        public Seller? Seller { get; set; }
        public Admin? Admin { get; set; }
    }
}
