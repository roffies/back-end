using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roffies.Api.Contexts.Workshops.Domain.Models;

public class WorkshopService
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [ForeignKey("Workshop")]
    public Guid WorkshopId { get; set; }
    public Workshop Workshop { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
}