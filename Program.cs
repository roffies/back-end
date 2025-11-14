using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using Roffies.Api.Contexts.Appointments.Application.CommandServices;
using Roffies.Api.Contexts.Appointments.Application.QueryServices;
using Roffies.Api.Contexts.Appointments.Domain.Infraestructure;
using Roffies.Api.Contexts.Appointments.Domain.Services;
using Roffies.Api.Contexts.Shared.Infraestructure;
using Roffies.Api.Contexts.Vehicles.Application.CommandServices;
using Roffies.Api.Contexts.Vehicles.Application.QueryServices;
using Roffies.Api.Contexts.Vehicles.Domain.Infraestructure;
using Roffies.Api.Contexts.Vehicles.Infraestructure.Repositories;
using Roffies.Api.Contexts.Workshops.Application.CommandServices;
using Roffies.Api.Contexts.Workshops.Application.QueryServices;
using Roffies.Api.Contexts.Workshops.Domain.Infraestructure;
using Roffies.Api.Contexts.Workshops.Domain.Services;
using Roffies.Api.Contexts.Workshops.Infraestructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddDbContext<RoffiesDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySQL(connectionString);
});

//Appointment
builder.Services.AddScoped<IAppointmentRepository,AppointmentRepository>();
builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>();
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();
//Vehicle
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleQueryService, VehicleQueryService>();
builder.Services.AddScoped<IVehicleCommandService, VehicleCommandService>();
//Workshop
builder.Services.AddScoped<IWorkshopRepository, WorkshopRepository>();
builder.Services.AddScoped<IWorkshopQueryService, WorkshopQueryService>();
builder.Services.AddScoped<IWorkshopCommandService, WorkshopCommandService>();

builder.Services.AddControllers();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RoffiesDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();