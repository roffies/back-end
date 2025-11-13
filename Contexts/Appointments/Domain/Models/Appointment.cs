using Roffies.Api.Contexts.Shared.Domain.Model;

namespace Roffies.Api.Contexts.Appointments.Domain.Models;

public class Appointment : BaseEntity
{

    public int UserId { get; set; }
    public int WorkshopId { get; set; }
    public int VehicleId { get; set; }
    public string Service { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public string Status { get; set; }
    public float EstimatedDuration { get; set; }
    public float EstimatedCost { get; set; }
    public string Notes { get; set; }
}