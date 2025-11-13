using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using Roffies.Api.Contexts.Appointments.Application.CommandServices;
using Roffies.Api.Contexts.Appointments.Application.QueryServices;
using Roffies.Api.Contexts.Appointments.Domain;
using Roffies.Api.Contexts.Appointments.Domain.Infraestructure;
using Roffies.Api.Contexts.Appointments.Domain.Services;
using Roffies.Api.Contexts.Appointments.Infraestructure.Persistence;


var builder = WebApplication.CreateBuilder(args);

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddDbContext<AppointmentDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySQL(connectionString);
});

builder.Services.AddScoped<IAppointmentQueryService, AppointmentQueryService>();
builder.Services.AddScoped<IAppointmentCommandService, AppointmentCommandService>();

builder.Services.AddControllers();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppointmentDbContext>();
    db.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();