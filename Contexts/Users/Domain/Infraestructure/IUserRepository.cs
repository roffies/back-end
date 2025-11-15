using Roffies.Api.Contexts.Users.Domain.Models;

namespace Roffies.Api.Contexts.Users.Domain.Infraestructure;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task<User?> FindByIdAsync(Guid id);
    Task<User?> FindByEmailAsync(string email);
    Task AddAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(User user);
}