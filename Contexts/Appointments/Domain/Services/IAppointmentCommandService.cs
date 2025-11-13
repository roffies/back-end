using Roffies.Api.Contexts.Appointments.Domain.Models;

namespace Roffies.Api.Contexts.Appointments.Domain.Services;

public interface IAppointmentCommandService
{
    Task<Appointment> CreateAsync(Appointment appointment);
    Task<bool> UpdateAsync(Guid id, Appointment updated);
    Task<bool> DeleteAsync(Guid id);
}