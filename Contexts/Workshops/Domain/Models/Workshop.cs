using System.ComponentModel.DataAnnotations;

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
}