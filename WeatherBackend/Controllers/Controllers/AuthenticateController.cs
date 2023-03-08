using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Weather.Core.Enums;
using Weather.Core.IServices;
using Weather.Core.Models;
using Weather.Messages.Requests;
using Weather.Messages.Responses;

namespace Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticateController : ControllerBase
{
    private readonly IAuthenticateService authenticateService;
    private readonly ILogger<AuthenticateController> logger;
    private readonly IMapper mapper;

    public AuthenticateController(
        ILogger<AuthenticateController> logger,
        IMapper mapper,
        IPlantService plantService,
        IAuthenticateService authenticateService
        )
    {
        this.authenticateService = authenticateService;
        this.logger = logger;
        this.mapper = mapper;
    }

    [HttpPost]
    [Route("Register")]
    public async Task<ActionResult<GetPlantsResponse>> RegisterUser(RegisterRequest request)
    {
        ActionResult result = null;
        try
        {
            var createdUser = await authenticateService.RegisterUser(request);
            result = Ok(new RegisterResponse
            {
                Status = "Success"
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception occurred");
            result = StatusCode(StatusCodes.Status500InternalServerError);
        }

        return result;
    }
    [HttpDelete]
    [Authorize(Roles = Roles.AdminRole)]
    [Route("DeleteUser")]
    public async Task<ActionResult<GetPlantsResponse>> DeleteUser(DeleteUserRequest request)
    {
        ActionResult result = null;
        try
        {
            await authenticateService.DeleteUser(request);
            result = Ok(new RegisterResponse
            {
                Status = "Success"
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception occurred");
            result = StatusCode(StatusCodes.Status500InternalServerError);
        }

        return result;
    }
}

