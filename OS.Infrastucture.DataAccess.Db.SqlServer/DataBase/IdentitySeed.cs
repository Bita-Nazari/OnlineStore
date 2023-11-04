
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.Db.SqlServer.DataBase
{
    public class IdentitySeed
    {

        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public IdentitySeed(UserManager<User> userManager , RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            
        }

        public async Task Create()
        {
            if(_userManager.Users.Count() == 0)
            {
                var User = new User()
                {
                    Id = 1,
                    Email = "nazaribita33@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+989035078580",
                    NormalizedEmail = "NAZARIBITA33@GMAIL.COM",
                    UserName = "Bita33",
                    NormalizedUserName = "BITA33",
                    PhoneNumberConfirmed = true,

                };

                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Customer"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Seller"));

                await _userManager.CreateAsync(User , "Bit95078580");
                await _userManager.AddToRoleAsync(User, "Admin");
            }
        }
    }
}
