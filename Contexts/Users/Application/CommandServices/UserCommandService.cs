using Roffies.Api.Contexts.Users.Domain.Infraestructure;
using Roffies.Api.Contexts.Users.Domain.Models;
using Roffies.Api.Contexts.Users.Domain.Services;

namespace Roffies.Api.Contexts.Users.Application.CommandServices;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository repository;

    public UserCommandService(IUserRepository repository)
    {
        this.repository = repository;
    }

    public async Task<User> CreateAsync(User user)
    {
        user.Validate();
        await repository.AddAsync(user);
        return user;
    }

    public async Task<bool> UpdateAsync(Guid id, User updated)
    {
        var user = await repository.FindByIdAsync(id);
        if (user == null) return false;

        user.Name = updated.Name;
        user.Phone = updated.Phone;
        user.Role = updated.Role;
        user.Avatar = updated.Avatar;
        user.Rating = updated.Rating;
        user.MemberSince = updated.MemberSince;
        user.Validate();

        await repository.UpdateAsync(user);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await repository.FindByIdAsync(id);
        if (user == null) return false;

        await repository.DeleteAsync(user);
        return true;
    }
}