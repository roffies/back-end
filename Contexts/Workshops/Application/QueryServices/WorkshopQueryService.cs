using Roffies.Api.Contexts.Workshops.Domain.Infraestructure;
using Roffies.Api.Contexts.Workshops.Domain.Models;
using Roffies.Api.Contexts.Workshops.Domain.Services;

namespace Roffies.Api.Contexts.Workshops.Application.QueryServices;

public class WorkshopQueryService : IWorkshopQueryService
{
    private readonly IWorkshopRepository repository;

    public WorkshopQueryService(IWorkshopRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IEnumerable<Workshop>> GetAllAsync()
        => await repository.GetAllAsync();

    public async Task<Workshop?> GetByIdAsync(Guid id)
        => await repository.FindByIdAsync(id);
}