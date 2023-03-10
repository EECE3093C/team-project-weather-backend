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
using Weather.Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Student Teacher API",
        Version = "v1",
        Description = "Student Teacher API Services.",
        Contact = new OpenApiContact
        {
            Name = "Ajide Habeeb."
        },
    });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddDbContext<PlantDbContext>(options =>
{
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
}, ServiceLifetime.Transient);
builder.Services.AddIdentity<AspNetUser, IdentityRole>()
        .AddEntityFrameworkStores<PlantDbContext>()
        .AddDefaultTokenProviders();
// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
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

// Repositories
builder.Services.AddTransient<IRepository<AspNetRole>, Repository<AspNetRole>>();
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

app.MapControllers();

app.Run();

