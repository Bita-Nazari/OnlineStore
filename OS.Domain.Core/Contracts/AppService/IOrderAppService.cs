using OS.Domain.Core.Dtos;

namespace OS.Domain.Core.Contracts.AppService
{
    public interface IOrderAppService
    {

        Task HardDelete(int OrderId, CancellationToken cancellationToken);
        Task SoftDelete(int OrderId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllCustomerOrder(int customerId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken);
        Task Detail(int orderId, CancellationToken cancellationToken);




    }
}
