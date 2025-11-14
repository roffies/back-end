using Roffies.Api.Contexts.Workshops.Domain.Models;

namespace Roffies.Api.Contexts.Workshops.Domain.Services;

public interface IWorkshopCommandService
{
    Task<Workshop> CreateAsync(Workshop workshop);
    Task<bool> UpdateAsync(Guid id, Workshop updated);
    Task<bool> DeleteAsync(Guid id);
}