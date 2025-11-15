using Roffies.Api.Contexts.Shared.Domain.Exceptions;
using Roffies.Api.Contexts.Shared.Domain.Model;

namespace Roffies.Api.Contexts.Appointments.Domain.Models;

public class Appointment : BaseEntity
{

    public int UserId { get; set; }
    public int WorkshopId { get; set; }
    public int VehicleId { get; set; }
    public string Service { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Time { get; set; }
    public string Status { get; set; } = "pending";
    public float EstimatedDuration { get; set; }
    public float EstimatedCost { get; set; }
    public string Notes { get; set; }

    //Reglas de Negocio
    public void Validate()
    {
        var appointmentDateTime = Date.Date;

        if (appointmentDateTime < DateTime.UtcNow)
            throw new DomainException("Appointments can not be in past.");

        if (EstimatedDuration <= 0)
            throw new DomainException("Estimated duration must be positive.");

        string[] validStatuses = { "pending", "confirmed", "completed", "cancelled" };
        if (!validStatuses.Contains(Status.ToLower()))
            throw new DomainException("Invalid appointment status.");    
    }
}