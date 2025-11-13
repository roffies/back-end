using Roffies.Api.Contexts.Vehicles.Domain.Models;

namespace Roffies.Api.Contexts.Vehicles.Domain.Infraestructure;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> ListAsync();
    Task<Vehicle?> FindByIdAsync(Guid id);
    Task AddAsync(Vehicle vehicle);
    Task UpdateAsync(Vehicle vehicle);
    Task DeleteAsync(Guid id);
}