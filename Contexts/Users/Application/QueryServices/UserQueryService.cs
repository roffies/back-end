using Roffies.Api.Contexts.Users.Domain.Infraestructure;
using Roffies.Api.Contexts.Users.Domain.Models;
using Roffies.Api.Contexts.Users.Domain.Services;

namespace Roffies.Api.Contexts.Users.Application.QueryServices;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository repository;

    public UserQueryService(IUserRepository repository)
    {
        this.repository = repository;
    }

    public Task<IEnumerable<User>> GetAllAsync()
        => repository.ListAsync();

    public Task<User?> GetByIdAsync(Guid id)
        => repository.FindByIdAsync(id);

    public Task<User?> GetByEmailAsync(string email)
        => repository.FindByEmailAsync(email);
}