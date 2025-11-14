using Roffies.Api.Contexts.Vehicles.Domain.Infraestructure;
using Roffies.Api.Contexts.Vehicles.Domain.Models;

namespace Roffies.Api.Contexts.Vehicles.Application.QueryServices;

public class VehicleQueryService : IVehicleQueryService
{
    private readonly IVehicleRepository _repository;

    public VehicleQueryService(IVehicleRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await _repository.ListAsync();
    }
    

    public Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return _repository.GetByIdAsync(id);
    }
}