using Roffies.Api.Contexts.Workshops.Domain.Models;

namespace Roffies.Api.Contexts.Workshops.Domain.Infraestructure;

public interface IWorkshopRepository
{
    Task<IEnumerable<Workshop>> GetAllAsync();
    Task<Workshop?> FindByIdAsync(Guid id);
    Task AddAsync(Workshop workshop);
    Task UpdateAsync(Workshop workshop);
    Task DeleteAsync(Workshop workshop);
}