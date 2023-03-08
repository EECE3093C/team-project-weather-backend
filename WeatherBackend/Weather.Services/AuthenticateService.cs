using Microsoft.AspNetCore.Identity;
using Weather.Core.IRepository;
using Weather.Core.IServices;
using Weather.Core.Models;
using Weather.Messages.Requests;
using AutoMapper;

namespace Weather.Services;

public class AuthenticateService : IAuthenticateService
{
    private readonly IMapper mapper;
    private readonly IPasswordHasher<AspNetUser> passwordHasher;
    private readonly IAspNetUserRepository aspNetUserRepository;

    public AuthenticateService(
        IPasswordHasher<AspNetUser> passwordHasher,
        UserManager<AspNetUser> userManager,
        IMapper mapper,
        IAspNetUserRepository aspNetUserRepository
        )
    {
        this.passwordHasher = passwordHasher;
        this.mapper = mapper;
        this.aspNetUserRepository = aspNetUserRepository;
    }

    public async Task<AspNetUser> RegisterUser(RegisterRequest request)
    {
        try
        {
            var user = new AspNetUser()
            {
                Email = request.Email,
                UserName = request.Username,
                PhoneNumber = request.PhoneNumber
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
            await aspNetUserRepository.DeleteAsync(userToDelete);
        }
        catch(Exception e)
        {
            throw e;
        }
    }
}

