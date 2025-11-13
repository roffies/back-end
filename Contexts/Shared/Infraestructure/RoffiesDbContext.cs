using Microsoft.EntityFrameworkCore;
using Roffies.Api.Contexts.Appointments.Domain.Models;
using Roffies.Api.Contexts.Vehicles.Domain.Models;

namespace Roffies.Api.Contexts.Shared.Infraestructure;

public class RoffiesDbContext : DbContext
{
    public RoffiesDbContext(DbContextOptions<RoffiesDbContext> options) : base(options) { }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Appointment>().ToTable("appointments");
        modelBuilder.Entity<Vehicle>().ToTable("vehicles");
    }
}