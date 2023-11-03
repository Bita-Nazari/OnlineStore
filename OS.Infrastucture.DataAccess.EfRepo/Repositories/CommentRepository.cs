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

        public Task<List<CommentDto>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<CommentDto>> GetProductComments(int productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task HardDelete(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(int commentId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
