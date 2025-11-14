using Microsoft.EntityFrameworkCore;
using Roffies.Api.Contexts.Shared.Infraestructure;
using Roffies.Api.Contexts.Vehicles.Domain.Infraestructure;
using Roffies.Api.Contexts.Vehicles.Domain.Models;

namespace Roffies.Api.Contexts.Vehicles.Infraestructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly RoffiesDbContext _context;

    public VehicleRepository(RoffiesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Vehicle>> ListAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();
    }


    
    public async Task<Vehicle?> GetByIdAsync(Guid id)
    {
        return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
    }

    public async Task UpdateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle != null)
        {
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}