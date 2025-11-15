using Roffies.Api.Contexts.Users.Domain.Models;

namespace Roffies.Api.Contexts.Users.Domain.Services;

public interface IUserCommandService
{
    Task<User> CreateAsync(User user);
    Task<bool> UpdateAsync(Guid id, User updated);
    Task<bool> DeleteAsync(Guid id);
}