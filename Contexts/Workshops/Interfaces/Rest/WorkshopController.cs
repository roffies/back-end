using Microsoft.AspNetCore.Mvc;
using Roffies.Api.Contexts.Workshops.Domain.Models;
using Roffies.Api.Contexts.Workshops.Domain.Services;

namespace Roffies.Api.Contexts.Workshops.Interfaces.Rest;

[ApiController]
[Route("api/[controller]")]
public class WorkshopController : ControllerBase
{
    private readonly IWorkshopQueryService queryService;
    private readonly IWorkshopCommandService commandService;

    public WorkshopController(
        IWorkshopQueryService queryService,
        IWorkshopCommandService commandService)
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
        var workshop = await queryService.GetByIdAsync(id);
        return workshop == null ? NotFound() : Ok(workshop);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Workshop request)
    {
        var newWorkshop = await commandService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = newWorkshop.Id }, newWorkshop);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, Workshop request)
    {
        var updated = await commandService.UpdateAsync(id, request);
        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await commandService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}