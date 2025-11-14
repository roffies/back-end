using Roffies.Api.Contexts.Workshops.Domain.Models;

namespace Roffies.Api.Contexts.Workshops.Domain.Infraestructure;

public interface IWorkshopServiceRepository
{
    Task<IEnumerable<WorkshopService>> GetByWorkshopIdAsync(Guid workshopId);
    Task<WorkshopService?> FindByIdAsync(Guid id);
    Task AddAsync(WorkshopService service);
    Task UpdateAsync(WorkshopService service);
    Task DeleteAsync(WorkshopService service);
}