using Roffies.Api.Contexts.Appointments.Domain.Infraestructure;
using Roffies.Api.Contexts.Appointments.Domain.Models;
using Roffies.Api.Contexts.Appointments.Domain.Services;

namespace Roffies.Api.Contexts.Appointments.Application.CommandServices;

public class AppointmentCommandService(IAppointmentRepository appointmentRepository)
    : IAppointmentCommandService
{
    public async Task<Appointment> CreateAsync(Appointment appointment)
    {
        await appointmentRepository.AddAsync(appointment);
        return appointment;
    }

    public async Task<bool> UpdateAsync(Guid id, Appointment updated)
    {
        var appointment = await appointmentRepository.FindByIdAsync(id);
        if (appointment == null) return false;
        
        appointment.Service = updated.Service;
        appointment.Date = updated.Date;
        appointment.Time = updated.Time;
        appointment.Status = updated.Status;
        appointment.EstimatedDuration = updated.EstimatedDuration;
        appointment.EstimatedCost = updated.EstimatedCost;
        appointment.Notes = updated.Notes;

        await appointmentRepository.UpdateAsync(appointment);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var appointment = await appointmentRepository.FindByIdAsync(id);
        if (appointment == null) return false;

        await appointmentRepository.DeleteAsync(appointment);
        return true;
    }
}