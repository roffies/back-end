using System.Text.RegularExpressions;
using Roffies.Api.Contexts.Shared.Domain.Exceptions;

namespace Roffies.Api.Contexts.Users.Domain.Models;

public class User
{
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Role { get; set; }
    public string Avatar { get; set; }
    public float Rating { get; set; }
    public string MemberSince { get; set; }
    
    public void Validate()
    {
        if (!Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new DomainException("Invalid email format.");

        if (Password.Length < 8)
            throw new DomainException("Password must be at least 8 characters.");

        string[] validRoles = { "driver", "admin", "mechanic" };
        if (!validRoles.Contains(Role.ToLower()))
            throw new DomainException("Invalid user role.");
    }
}