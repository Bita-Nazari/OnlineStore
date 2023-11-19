using Microsoft.EntityFrameworkCore;
using OS.Domain.Core.Contracts.Repository;
using OS.Domain.Core.Dtos;
using OS.Domain.Core.Entities;
using OS.Infrastucture.Db.SqlServer.DataBase;

namespace OS.Infrastucture.DataAccess.EfRepo.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly OnlineStoreContext _storeContext;
        public CommentRepository(OnlineStoreContext storeContext)
        {
            _storeContext = storeContext;
        }
        public async Task Create(CommentDto commentDto, CancellationToken cancellationToken)
        {
            var comment = new Comment()
            {
                Text = commentDto.Text,
                Id = commentDto.Id,

            }; 
           await _storeContext.Comments.AddAsync(comment);
           await _storeContext.SaveChangesAsync();


        }

        public Task<CommentDto> Detail(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
           
            var Comments = await _storeContext.Comments.Include(x=> x.Booth).Include(c=>c.Customer).Select(
               x=> new CommentDto
               {
                   Text= x.Text,
                   Id = x.Id,
                   IsDeleted= x.IsDeleted,
                   IsConfirmed= x.IsConfirmed,
                   BoothName = x.Booth.Name,
                   CustomerName = x.Customer.FirstName + " "+ x.Customer.LastName,

               }
                
                
                ).ToListAsync(cancellationToken);
            return Comments;
        }

        public Task<List<CommentDto>> GetProductComments(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Confirm(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
