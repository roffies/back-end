using Roffies.Api.Contexts.Workshops.Domain.Infraestructure;
using Roffies.Api.Contexts.Workshops.Domain.Models;
using Roffies.Api.Contexts.Workshops.Domain.Services;

namespace Roffies.Api.Contexts.Workshops.Application.CommandServices;

public class WorkshopCommandService : IWorkshopCommandService
{
    private readonly IWorkshopRepository repository;

    public WorkshopCommandService(IWorkshopRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Workshop> CreateAsync(Workshop workshop)
    {
        workshop.Validate();
        await repository.AddAsync(workshop);
        return workshop;
    }

    public async Task<bool> UpdateAsync(Guid id, Workshop updated)
    {
        var workshop = await repository.FindByIdAsync(id);
        if (workshop == null) return false;

        workshop.Name = updated.Name;
        workshop.Address = updated.Address;
        workshop.Phone = updated.Phone;
        workshop.Email = updated.Email;
        workshop.Rating = updated.Rating;
        workshop.Hours = updated.Hours;
        workshop.Latitude = updated.Latitude;
        workshop.Longitude = updated.Longitude;
        workshop.Status = updated.Status;
        workshop.Validate();

        await repository.UpdateAsync(workshop);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var workshop = await repository.FindByIdAsync(id);
        if (workshop == null) return false;

        await repository.DeleteAsync(workshop);
        return true;
    }
}