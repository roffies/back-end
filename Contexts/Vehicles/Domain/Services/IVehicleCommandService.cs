using Roffies.Api.Contexts.Vehicles.Domain.Models;

namespace Roffies.Api.Contexts.Vehicles.Application.QueryServices;

public interface IVehicleCommandService
{
    Task AddAsync(Vehicle vehicle);
    Task<bool> DeleteAsync(Guid id);
}