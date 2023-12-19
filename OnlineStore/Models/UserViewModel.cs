namespace OnlineStore.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ConfirmPassword { get; set; }
        public int? SellerId { get; set; }
        public int? CustomerId { get; set; }
        public string? Role { get; set; }
        public bool IsSeller { get; set; }
        public List<string>? Roles { get; set; }
        public int? CustomerCount { get; set; }
        public int? BoothCount { get; set; }
        public int? CommentCount { get; set; }
        public int? OrderCount { get; set; }
    }
}
