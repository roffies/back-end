using Microsoft.EntityFrameworkCore;
using Roffies.Api.Contexts.Shared.Infraestructure;
using Roffies.Api.Contexts.Users.Domain.Infraestructure;
using Roffies.Api.Contexts.Users.Domain.Models;

namespace Roffies.Api.Contexts.Users.Infraestructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly RoffiesDbContext _context;

    public UserRepository(RoffiesDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> ListAsync()
        => await _context.Users.ToListAsync();

    public async Task<User?> FindByIdAsync(Guid id)
        => await _context.Users.FindAsync(id);

    public async Task<User?> FindByEmailAsync(string email)
        => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}