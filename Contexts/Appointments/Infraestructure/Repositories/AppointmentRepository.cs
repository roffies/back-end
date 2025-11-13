using Microsoft.EntityFrameworkCore;
using Roffies.Api.Contexts.Appointments.Domain.Infraestructure;
using Roffies.Api.Contexts.Appointments.Domain.Models;
using Roffies.Api.Contexts.Appointments.Infraestructure.Persistence;
using Roffies.Api.Contexts.Shared.Infraestructure;


public class AppointmentRepository : IAppointmentRepository
    {
        private readonly RoffiesDbContext _context;

        public AppointmentRepository(RoffiesDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Appointment>> ListAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task<Appointment?> FindByIdAsync(Guid id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Appointment appointment)
        {
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
        }
    }