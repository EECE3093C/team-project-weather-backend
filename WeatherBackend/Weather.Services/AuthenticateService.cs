using Microsoft.AspNetCore.Identity;
using Weather.Core.IRepository;
using Weather.Core.IServices;
using Weather.Core.Models;
using Weather.Messages.Requests;
using AutoMapper;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Weather.Core.Enums;
using Z.Expressions;
using Weather.Core.Exceptions;

namespace Weather.Services;

public class AuthenticateService : IAuthenticateService
{
    private readonly IMapper mapper;
    private readonly IPasswordHasher<AspNetUser> passwordHasher;
    private readonly IAspNetUserRepository aspNetUserRepository;
    private readonly IConfiguration configuration;

    public AuthenticateService(
        IPasswordHasher<AspNetUser> passwordHasher,
        UserManager<AspNetUser> userManager,
        IMapper mapper,
        IAspNetUserRepository aspNetUserRepository,
        IConfiguration configuration
        )
    {
        this.passwordHasher = passwordHasher;
        this.mapper = mapper;
        this.aspNetUserRepository = aspNetUserRepository;
        this.configuration = configuration;
    }

    public async Task<AspNetUser> RegisterUser(RegisterRequest request)
    {
        try
        {
            var user = new AspNetUser()
            {
                UserName = request.Username,
                NormalizedUserName = request.Username.ToUpper(),
                Email = request.Email,
                NormalizedEmail = request.Email.ToUpper(),
                PhoneNumber = request.PhoneNumber,
                Id = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
            };
            user.PasswordHash = passwordHasher.HashPassword(user, request.Password);
            var userResponse = await aspNetUserRepository.AddAsync(user);
            return userResponse;
        }
        catch(Exception e)
        {
            throw e;
        }
    }

    public async Task DeleteUser(DeleteUserRequest request)
    {
        try
        {
            var userToDelete = await aspNetUserRepository.GeyByCondition(u => u.UserName == request.Username);
            if (userToDelete != null)
            {
                await aspNetUserRepository.DeleteAsync(userToDelete);
            }
            else
            {
                throw new NotFoundException($"User {request.Username} doesn't exist");
            }
        }
        catch(Exception e)
        {
            throw e;

        }
    }
    public async Task<string> Login(LoginRequest request)
    {
        try
        {
            var user = await aspNetUserRepository.GeyByCondition(u => u.UserName == request.Username);
            if(user != null)
            {
                var verification = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
                if(verification == PasswordVerificationResult.Success)
                {
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Role, Roles.AdminRole)
                    };

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));
                    var token = new JwtSecurityToken(
                        issuer: configuration["JWT:ValidIssuer"],
                        audience: configuration["JWT:ValidAudience"],
                        expires: DateTime.UtcNow.AddMinutes(90),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }
            }
            throw new Exception();
        }
        catch(Exception e)
        {
            throw e;
        }
    }
}

