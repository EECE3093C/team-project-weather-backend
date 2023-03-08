using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Weather.Core.Models;
using AutoMapper;
using Weather.Messages;
using Weather.Infrastructure.Mappers;
using Weather.Core.IRepository;
using Weather.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Weather.Core.IServices;
using Weather.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Weather.Core.Enums;

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
builder.Services.AddDbContext<PlantDbContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Transient);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(Policies.AdminPolicy, builder => builder.RequireRole(Roles.AdminRole));
});
builder.Services.AddAutoMapper(typeof(MessageMappingProfile));

//Services
builder.Services.AddTransient<IPlantService, PlantService>();
builder.Services.AddTransient<IAuthenticateService, AuthenticateService>();
builder.Services.AddTransient<IPasswordHasher<AspNetUser>, PasswordHasher<AspNetUser>>()
.Configure<PasswordHasherOptions>(options =>
{
    options.IterationCount = 1000;
    options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
});
builder.Services.AddIdentity<AspNetUser, IdentityRole>()
        .AddEntityFrameworkStores<PlantDbContext>()
        .AddDefaultTokenProviders();
// Repositories
builder.Services.AddTransient<IPlantRepository, PlantRepository>();
builder.Services.AddTransient<IAspNetUserRepository, AspNetUserRepository>();

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

