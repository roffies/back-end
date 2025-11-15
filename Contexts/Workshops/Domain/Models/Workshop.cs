using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Roffies.Api.Contexts.Shared.Domain.Exceptions;

namespace Roffies.Api.Contexts.Workshops.Domain.Models;

public class Workshop
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public double Rating { get; set; }
    public string Hours { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Status { get; set; }

    public List<WorkshopService> Services { get; set; } = new();
    
    public void Validate()
    {
        if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new DomainException("Invalid email address.");

        if (Rating < 0 || Rating > 5)
            throw new DomainException("Rating must be between 0 and 5.");

        if (Services.Count == 0)
            throw new DomainException("Must have at least one service.");
    }
}