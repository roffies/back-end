using Microsoft.AspNetCore.Mvc;
using Roffies.Api.Contexts.Appointments.Domain.Models;
using Roffies.Api.Contexts.Appointments.Domain.Services;

namespace Roffies.Api.Contexts.Appointments.Interfaces.Rest;

[ApiController]
[Route("api/[controller]")]
public class AppointmentController : ControllerBase
{
    private readonly IAppointmentQueryService queryService;
    private readonly IAppointmentCommandService commandService;

    public AppointmentController(
        IAppointmentQueryService queryService,
        IAppointmentCommandService commandService)
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
        var appointment = await queryService.GetByIdAsync(id);
        return appointment == null ? NotFound() : Ok(appointment);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Appointment request)
    {
        var newAppointment = await commandService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = newAppointment.Id }, newAppointment);
    }
}