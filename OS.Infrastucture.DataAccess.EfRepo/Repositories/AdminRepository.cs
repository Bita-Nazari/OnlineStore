using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Infrastucture.Db.SqlServer.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public AdminRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task EditAdmin(AlluserDto user, CancellationToken cancellationToken)
        {
            var admin = await _storeContext.Admins.Where(a => a.UserId == user.Id)
                 .Include(a => a.User)
                 .FirstOrDefaultAsync();
            if (admin == null)
            {
                throw new Exception("user did not found");
            }

            admin.FirstName = user.FirstName;
            admin.LastName = user.LastName;
            admin.User.PhoneNumber = user.PhoneNumber;
            admin.User.UserName = user.UserName;
            admin.User.Email = user.Email;
            await _storeContext.SaveChangesAsync();
        }

        public Task<AlluserDto> GetAdminById(int AdminId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AlluserDto> GetAdminByUserId(int Userid, CancellationToken cancellationToken)
        {
            var admin = await _storeContext.Admins.Where(a => a.UserId == Userid)
                .Include(a=> a.User)
                .FirstOrDefaultAsync();
            var admindto = new AlluserDto
            {
                FirstName = admin.FirstName
                ,
                Email = admin.User.Email,
                PhoneNumber = admin.User.PhoneNumber,
                UserName = admin.User.UserName,
                LastName = admin.LastName,
                Wallet = admin.Wallet
            };
            return admindto;
        }
    }
}
