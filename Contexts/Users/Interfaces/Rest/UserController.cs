using Microsoft.AspNetCore.Mvc;
using Roffies.Api.Contexts.Users.Domain.Models;
using Roffies.Api.Contexts.Users.Domain.Services;

namespace Roffies.Api.Contexts.Users.Interfaces.Rest;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserQueryService queryService;
    private readonly IUserCommandService commandService;

    public UserController(
        IUserQueryService queryService,
        IUserCommandService commandService)
    {
        this.queryService = queryService;
        this.commandService = commandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await queryService.GetAllAsync());

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await queryService.GetByIdAsync(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create(User request)
    {
        var newUser = await commandService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = newUser.Id }, newUser);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, User request)
        => await commandService.UpdateAsync(id, request)
            ? Ok() : NotFound();

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
        => await commandService.DeleteAsync(id)
            ? Ok() : NotFound();
}