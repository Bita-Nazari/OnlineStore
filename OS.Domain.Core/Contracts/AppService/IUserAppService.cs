using Microsoft.AspNetCore.Identity;
using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.AppService
{
    public interface IUserAppService
    {
        public Task<IdentityResult> SignUp(UserDto userDto, CancellationToken cancellationtoken);
        public Task<SignInResult> LogIn(UserDto userDto, CancellationToken cancellationtoken);
        public Task LogOut(CancellationToken cancellationtoken);
        public Task<List<string>> GetRole(int userId , CancellationToken cancellationToken);
        public Task<UserDto>FindUserByName(string userName, CancellationToken cancellationToken);
        public Task<List<UserDto>> GetAll(CancellationToken cancellationToken);
        public Task<UserDto>GetById(int id, CancellationToken cancellationToken);   
    }
}
