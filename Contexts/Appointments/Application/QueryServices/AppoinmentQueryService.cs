using Roffies.Api.Contexts.Appointments.Domain.Infraestructure;
using Roffies.Api.Contexts.Appointments.Domain.Models;
using Roffies.Api.Contexts.Appointments.Domain.Services;

namespace Roffies.Api.Contexts.Appointments.Application.QueryServices;

public class AppointmentQueryService(IAppointmentRepository appointmentRepository)
    : IAppointmentQueryService
{
    public async Task<IEnumerable<Appointment>> GetAllAsync()
        => await appointmentRepository.ListAsync();

    public async Task<Appointment?> GetByIdAsync(Guid id)
        => await appointmentRepository.FindByIdAsync(id);
}