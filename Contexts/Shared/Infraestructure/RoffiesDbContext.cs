using Microsoft.EntityFrameworkCore;
using Roffies.Api.Contexts.Appointments.Domain.Models;
using Roffies.Api.Contexts.Users.Domain.Models;
using Roffies.Api.Contexts.Vehicles.Domain.Models;
using Roffies.Api.Contexts.Workshops.Domain.Models;

namespace Roffies.Api.Contexts.Shared.Infraestructure;

public class RoffiesDbContext : DbContext
{
    public RoffiesDbContext(DbContextOptions<RoffiesDbContext> options) : base(options) { }

    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    
    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<WorkshopService> WorkshopServices { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Appointment>().ToTable("appointments");
        modelBuilder.Entity<Vehicle>().ToTable("vehicles");
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Workshop>().ToTable("workshops");
        modelBuilder.Entity<WorkshopService>().ToTable("workshop_services");
        modelBuilder.Entity<Workshop>()
            .HasMany(w => w.Services)
            .WithOne(s => s.Workshop)
            .HasForeignKey(s => s.WorkshopId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}