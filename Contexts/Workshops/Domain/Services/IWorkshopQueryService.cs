using Roffies.Api.Contexts.Workshops.Domain.Models;

namespace Roffies.Api.Contexts.Workshops.Domain.Services;

public interface IWorkshopQueryService
{
    Task<IEnumerable<Workshop>> GetAllAsync();
    Task<Workshop?> GetByIdAsync(Guid id);
}