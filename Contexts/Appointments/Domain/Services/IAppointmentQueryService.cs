using Roffies.Api.Contexts.Appointments.Domain.Models;

namespace Roffies.Api.Contexts.Appointments.Domain.Services;

public interface IAppointmentQueryService
{
    Task<IEnumerable<Appointment>> GetAllAsync();
    Task<Appointment?> GetByIdAsync(Guid id);
}