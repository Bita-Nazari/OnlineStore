﻿namespace OnlineStore.Areas.Admin.Models
{
    public class UserAdminViewModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? Role { get; set; }
        public bool IsSeller { get; set; }
        public List<string>? Roles { get; set; }
    }
}
