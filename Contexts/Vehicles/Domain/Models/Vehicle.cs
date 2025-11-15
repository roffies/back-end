using System.Text.RegularExpressions;
using Roffies.Api.Contexts.Shared.Domain.Exceptions;

namespace Roffies.Api.Contexts.Vehicles.Domain.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }

    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;

    public int Year { get; set; }
    public string LicensePlate { get; set; } = string.Empty;

    public int Mileage { get; set; }
    public DateTime LastMaintenance { get; set; }
    public DateTime NextMaintenance { get; set; }

    public string Status { get; set; } = "active";

    public void Validate(int? previousMileage = null)
    {
        if (Year > DateTime.UtcNow.Year)
            throw new DomainException("Vehicle year can not be future.");

        if (!Regex.IsMatch(LicensePlate, "^[A-Z]{3}-[0-9]{3}$"))
            throw new DomainException("Invalid license plate: ABC-123.");

        if (previousMileage != null && Mileage < previousMileage)
            throw new DomainException("Vehicle mileage cannot decrease.");
    }
}