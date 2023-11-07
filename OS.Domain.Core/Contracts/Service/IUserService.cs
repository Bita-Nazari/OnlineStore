using Microsoft.AspNetCore.Identity;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Service
{
    public interface IUserService
    {
        public Task<IdentityResult> SignUp(UserDto userDto, CancellationToken cancellationtoken);
        public Task<SignInResult> LogIn(UserDto userDto, CancellationToken cancellationtoken);
        public Task LogOut(CancellationToken cancellationtoken);
        public Task<List<string>> GetRole(int userId , CancellationToken cancellationtoken);
        public Task<UserDto> FindUserByName(string userName, CancellationToken cancellationToken);
    }
}
