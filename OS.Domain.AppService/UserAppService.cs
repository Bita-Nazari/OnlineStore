using Microsoft.AspNetCore.Identity;
using OS.Domain.Core.Contracts.AppService;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.AppService
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        public UserAppService(IUserService userService)
        {
            _userService = userService;
        }

        public Task<UserDto> FindUserByName(string userName, CancellationToken cancellationToken)
        {
            return _userService.FindUserByName(userName, cancellationToken);
        }

        public async Task<List<string>> GetRole(int userId ,CancellationToken cancellationToken)
        {
            return await _userService.GetRole(userId ,cancellationToken);
        }

        public async Task<SignInResult> LogIn(UserDto userDto, CancellationToken cancellationtoken)
        {
           return await _userService.LogIn(userDto, cancellationtoken);
        }

        public async Task LogOut(CancellationToken cancellationtoken)
        {
            await _userService.LogOut(cancellationtoken);
        }

        public async Task<IdentityResult> SignUp(UserDto userDto, CancellationToken cancellationtoken)
        {
            return await _userService.SignUp(userDto, cancellationtoken);
        }
    }
}
