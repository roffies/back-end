using Roffies.Api.Contexts.Vehicles.Application.QueryServices;
using Roffies.Api.Contexts.Vehicles.Domain.Infraestructure;
using Roffies.Api.Contexts.Vehicles.Domain.Models;

namespace Roffies.Api.Contexts.Vehicles.Application.CommandServices;

public class VehicleCommandService : IVehicleCommandService
{
    private readonly IVehicleRepository _repository;

    public VehicleCommandService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task AddAsync(Vehicle vehicle)
    {
        await _repository.AddAsync(vehicle);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var existingVehicle = await _repository.GetByIdAsync(id);

        if (existingVehicle == null)
            return false;

        await _repository.DeleteAsync(id);
        return true;
    }
}