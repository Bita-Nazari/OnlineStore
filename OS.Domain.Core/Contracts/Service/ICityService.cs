using OS.Domain.Core.Dtos;

namespace OS.Domain.Core.Contracts.Service
{
    public interface ICityService
    {
        Task<List<CityDto>> GetAll(CancellationToken cancellationToken);
    }
}
