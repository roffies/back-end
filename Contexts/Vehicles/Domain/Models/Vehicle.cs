using Roffies.Api.Contexts.Shared;

namespace Roffies.Api.Contexts.Vehicles.Domain.Models;

public class Vehicle
{
    public Guid Id { get; set; }                
    public int UserId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Year { get; set; }
    public string LicensePlate { get; set; }
    public int Mileage { get; set; }
    public string LastMaintenance { get; set; }
    public string NextMaintenance { get; set; } 
    public string Status { get; set; }
}