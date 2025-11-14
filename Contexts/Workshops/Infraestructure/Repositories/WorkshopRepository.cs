using Microsoft.EntityFrameworkCore;
using Roffies.Api.Contexts.Shared.Infraestructure;
using Roffies.Api.Contexts.Workshops.Domain.Infraestructure;
using Roffies.Api.Contexts.Workshops.Domain.Models;

namespace Roffies.Api.Contexts.Workshops.Infraestructure.Repositories;

public class WorkshopRepository : IWorkshopRepository
{
    private readonly RoffiesDbContext _context;

    public WorkshopRepository(RoffiesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Workshop>> GetAllAsync()
        => await _context.Workshops
            .Include(w => w.Services)
            .ToListAsync();

    public async Task<Workshop?> FindByIdAsync(Guid id)
        => await _context.Workshops
            .Include(w => w.Services)
            .FirstOrDefaultAsync(w => w.Id == id);

    public async Task AddAsync(Workshop workshop)
    {
        _context.Workshops.Add(workshop);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Workshop workshop)
    {
        _context.Workshops.Update(workshop);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Workshop workshop)
    {
        _context.Workshops.Remove(workshop);
        await _context.SaveChangesAsync();
    }
}