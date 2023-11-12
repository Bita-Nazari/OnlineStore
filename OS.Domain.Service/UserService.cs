using Microsoft.AspNetCore.Identity;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Contracts.Service;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserDto> FindUserByName(string userName, CancellationToken cancellationToken)
        {
            return _userRepository.FindUserByName(userName, cancellationToken);
        }

        public Task<List<UserDto>> GetAll(CancellationToken cancellationToken)
        {
           return _userRepository.GetAll(cancellationToken);
        }


        public async Task<UserDto> GetById(int id, CancellationToken cancellationToken)
        {
           return await _userRepository.GetById(id, cancellationToken);
        }



    

        public async Task<List<string>> GetRole(int userId, CancellationToken cancellationtoken)
        {
            return await _userRepository.GetRole(userId, cancellationtoken);
        }

   

        public async Task<SignInResult> LogIn(UserDto userDto, CancellationToken cancellationtoken)
        {
            return await _userRepository.LogIn(userDto, cancellationtoken);
        }

        public async Task LogOut(CancellationToken cancellationtoken)
        {
            await _userRepository.LogOut(cancellationtoken);
        }

        public async Task<IdentityResult> SignUp(UserDto userDto, CancellationToken cancellationtoken)
        {
           return await _userRepository.SignUp(userDto, cancellationtoken);
        }
    }
}
