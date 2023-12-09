using OS.Domain.Core.Dtos;

namespace OS.Domain.Core.Contracts.AppService
{
    public interface IOrderAppService
    {
        Task Create (int? CartId ,CancellationToken cancellationToken);
        Task HardDelete(int OrderId, CancellationToken cancellationToken);
        Task SoftDelete(int OrderId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAll(CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllAuctionOrder(int customerId, CancellationToken cancellationToken);
        Task<OrderDto> DetailAuction(int orderId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllCustomerOrder(int customerId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllBoothOrders(int BoothId, CancellationToken cancellationToken);
        Task<OrderDto> Detail(int orderId, CancellationToken cancellationToken);
        Task<List<OrderDto>> GetAllCommessionOrders(CancellationToken cancellationToken);




    }
}
