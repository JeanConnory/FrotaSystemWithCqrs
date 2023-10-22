using FrotaApp.Application.Input.Commands.VehicleContext;
using FrotaApp.Application.Input.Receivers;
using FrotaApp.Application.Input.Repositories;
using FrotaApp.Application.Output.Interfaces;
using FrotaApp.Infrastructure.Input.Repositories;
using FrotaApp.Infrastructure.Output.Repositories;
using FrotaApp.Infrastructure.Shared.Factory;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<SqlFactory>();
builder.Services.AddTransient<IWriteVehicleRepository, WriteVehicleRepository>();
builder.Services.AddTransient<IReadVehicleRepository, ReadVehicleRepository>();
builder.Services.AddTransient<InsertVehicleReceiver>();


var app = builder.Build();

app.MapGet("/vehicle", ([FromServices] IReadVehicleRepository repository) =>
{
    return repository.GetVehicles();
});

app.MapGet("/vehicle/GetById", ([FromQuery] int id, [FromServices] IReadVehicleRepository repository) =>
{
    return repository.FindById(id);
});

app.MapGet("/vehicle/GetByCategoryId", ([FromQuery] int categoryId, [FromServices] IReadVehicleRepository repository) =>
{
    return repository.FindByCategoryId(categoryId);
});

app.MapPost("/vehicle/PostVehicle", ([FromServices] InsertVehicleReceiver receiver, [FromBody] VehicleCommand command) =>
{
    return receiver.Action(command);
});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();