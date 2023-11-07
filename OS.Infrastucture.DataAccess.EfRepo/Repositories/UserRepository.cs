using Microsoft.AspNetCore.Identity;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System.Data.Entity;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly OnlineStoreContext _onlineStoreContext;
        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, OnlineStoreContext onlineStoreContext)
        {
            _onlineStoreContext = onlineStoreContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<UserDto> FindUserByName(string userName, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                throw new NullReferenceException("User did not found");
            }
            var userdto = new UserDto()
            {
                Id = user.Id
            };

            return userdto;
        }

        public async Task<List<string>> GetRole(int userId, CancellationToken cancellationtoken)
        {
            var user = await _onlineStoreContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new NullReferenceException ("user did not found");
            }
            var role = await _userManager.GetRolesAsync(user);
            return role.ToList();
        }

        public async Task<SignInResult> LogIn(UserDto userDto, CancellationToken cancellationtoken)
        {

            return  await _signInManager.PasswordSignInAsync(userDto.UserName,userDto.Password,true,false);

            
        }

        public async Task LogOut(CancellationToken cancellationtoken)
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> SignUp(UserDto userDto, CancellationToken cancellationtoken)
        {

                var user = new User();
                if (userDto.IsSeller == true)
                {
                    userDto.Role = "Seller";
                user = new User()
                {

                    Id = userDto.Id,
                    UserName = userDto.UserName,
                    Email = userDto.Email,
                    PhoneNumber = userDto.PhoneNumber,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                
                        Seller = new Seller()
                        {
                            CreatedAt = DateTime.Now,
                        }

                    };

                }
                if (userDto.IsSeller == false)
                {
                    userDto.Role = "Customer";
                    user = new User()
                    {
                        Id = userDto.Id,
                        UserName = userDto.UserName,
                        Email = userDto.Email,
                        PhoneNumber = userDto.PhoneNumber,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                        Customer = new Customer()
                        {
                            CreatedAt = DateTime.Now,
                            
                        }
                    };
                }

                var resault = await _userManager.CreateAsync(user, userDto.Password);
                if (resault.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, userDto.Role);
                }

                return resault;
        }
    }
}
