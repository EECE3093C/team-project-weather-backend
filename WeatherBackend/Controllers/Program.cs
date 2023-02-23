using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Weather.Core.Models;
using AutoMapper;
using Weather.Messages;
using Weather.Infrastructure.Mappers;
using Weather.Core.IRepository;
using Weather.Infrastructure.Repositories;
using Weather.Core.IServices;
using Weather.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PlantDbContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Transient);
builder.Services.AddAutoMapper(typeof(MessageMappingProfile));

//Services
builder.Services.AddTransient<IPlantService, PlantService>();
// Repositories
builder.Services.AddTransient<IPlantRepository, PlantRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

