using Roffies.Api.Contexts.Users.Domain.Models;

namespace Roffies.Api.Contexts.Users.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> GetAllAsync();
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByEmailAsync(string email);
}