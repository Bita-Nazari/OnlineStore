using OS.Domain.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS.Domain.Core.Contracts.AppService
{
    public interface ICommentAppService
    {
        Task Create(CommentDto commentDto, CancellationToken cancellationToken);
        Task HardDelete(int commentId, CancellationToken cancellationToken);
        Task Update(int commentId, CancellationToken cancellationToken);
        Task<List<CommentDto>> GetAll(CancellationToken cancellationToken);
        Task<CommentDto> Detail(int commentId, CancellationToken cancellationToken);
        Task<List<CommentDto>>GetProductComments(int productId ,CancellationToken cancellationToken);
    }
}
