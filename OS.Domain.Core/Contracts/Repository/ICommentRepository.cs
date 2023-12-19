using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.Repository
{
    public interface ICommentRepository
    {
        Task Create(CommentDto commentDto, CancellationToken cancellationToken);
        Task HardDelete(int commentId, CancellationToken cancellationToken);
        Task Confirm(int commentId, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAllCustomerComment(int id, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task<CommentDto> Detail(int commentId, CancellationToken cancellationToken);
        Task<BoothDto> GetAllBoothComment(int boothid, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetProductComments(int productId, CancellationToken cancellationToken);
        public Task IsRestored(int id, CancellationToken cancellationToken);

    }
}
