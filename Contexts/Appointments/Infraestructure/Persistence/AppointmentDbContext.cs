using Microsoft.EntityFrameworkCore;
using Roffies.Api.Contexts.Appointments.Domain.Models;

namespace Roffies.Api.Contexts.Appointments.Infraestructure.Persistence
{
    public class AppointmentDbContext : DbContext
    {
        public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options)
            : base(options)
        {
        }

        public DbSet<Appointment> Appointments { get; set; }
    }
}