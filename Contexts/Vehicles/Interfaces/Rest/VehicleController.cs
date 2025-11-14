using Microsoft.AspNetCore.Mvc;
using Roffies.Api.Contexts.Vehicles.Application.QueryServices;
using Roffies.Api.Contexts.Vehicles.Application.CommandServices;
using Roffies.Api.Contexts.Vehicles.Domain.Models;

namespace Roffies.Api.Contexts.Vehicles.Interfaces.Rest;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleQueryService _queryService;
    private readonly IVehicleCommandService _commandService;

    public VehicleController(IVehicleQueryService queryService, IVehicleCommandService commandService)
    {
        _queryService = queryService;
        _commandService = commandService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var vehicles = await _queryService.GetAllAsync();
        return Ok(vehicles);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var vehicle = await _queryService.GetByIdAsync(id);
        if (vehicle == null)
            return NotFound();

        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Vehicle vehicle)
    {
        await _commandService.AddAsync(vehicle);
        return Ok(vehicle);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _commandService.DeleteAsync(id);
        return NoContent();
    }
}