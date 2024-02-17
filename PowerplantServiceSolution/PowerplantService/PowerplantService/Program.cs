using System;
using PowerplantService.BusinessLayer;
using PowerplantService.BusinessLayer.BasePowerplant;
using PowerplantService.BusinessLayer.Intefaces;
using PowerplantService.BusinessLayer.LoggerService;
using PowerplantService.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//Integrating Serilog for global error handling in file system
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.File("PowerserviceLog/log.txt", (Serilog.Events.LogEventLevel)RollingInterval.Hour)
    .CreateLogger();

builder.Host.UseSerilog();

// Add services to the container.

builder.Services.AddControllers();

//Adding dependencies
builder.Services.AddScoped<IFuelPowerPlant, GasPowerplant>();
builder.Services.AddScoped<IFuelPowerPlant, TurbojetPowerplant>();
builder.Services.AddScoped<IFuelPowerPlant, WindPowerPlant>();
builder.Services.AddScoped<IWindPowerPlant, WindPowerPlant>();
builder.Services.AddScoped<IMeritOrder, MeritOrder>();
builder.Services.AddScoped<IPlantAndPowerSelection, PlantAndPowerSelection>();
builder.Services.AddSingleton<ILoggerService, LoggerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Adding middleware for global error handling
app.UseMiddlewareClassTemplate();

app.MapControllers();

app.Run();