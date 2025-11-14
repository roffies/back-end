using Roffies.Api.Contexts.Vehicles.Domain.Models;

namespace Roffies.Api.Contexts.Vehicles.Application.QueryServices;

public interface IVehicleQueryService
{
    Task<IEnumerable<Vehicle>> GetAllAsync();
    Task<Vehicle?> GetByIdAsync(Guid id);
    
}
