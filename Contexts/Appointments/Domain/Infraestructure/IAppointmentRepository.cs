using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Roffies.Api.Contexts.Appointments.Domain.Models;

namespace Roffies.Api.Contexts.Appointments.Domain.Infraestructure;

public interface IAppointmentRepository 
{
    Task<IEnumerable<Appointment>> ListAsync();
    Task<Appointment?> FindByIdAsync(Guid id);
    Task AddAsync(Appointment appointment);
    Task UpdateAsync(Appointment appointment);
    Task DeleteAsync(Appointment appointment);
}