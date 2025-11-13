namespace Roffies.Api.Contexts.Appointments.Domain.Models;

public class Appointment
{
    public Guid Id { get; set; }
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