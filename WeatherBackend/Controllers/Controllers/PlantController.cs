using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Weather.Core.IServices;
using Weather.Core.Models;
using Weather.Messages.Responses;

namespace Controllers.Controllers;

[ApiController]
[Route("[controller]")]
public class PlantController : ControllerBase
{

    private readonly ILogger<PlantController> logger;
    private readonly IMapper mapper;
    private readonly IPlantService plantService;

    public PlantController(ILogger<PlantController> logger, IMapper mapper, IPlantService plantService)
    {
        this.logger = logger;
        this.mapper = mapper;
        this.plantService = plantService;
    }

    [HttpGet]
    [Route("GetAllPlants")]
    public async Task<ActionResult<GetAllPlantsResponse>> GetAllPlants()
    {
        ActionResult result = null;
        try
        {
            var plant = await this.plantService.GetAllPlantsAsync();
            result = new JsonResult(mapper.Map<List<GetAllPlantsResponse>>(plant));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception occurred");
            result = StatusCode(StatusCodes.Status500InternalServerError);
        }

        return result;
    }
    [HttpGet]
    [Route("GetPlantsFromWeather")]
    public async Task<ActionResult<GetAllPlantsResponse>> GetPlantsByWeather(int weatherID)
    {
        ActionResult result = null;
        try
        {
            var plant = await this.plantService.GetPlantsByWeather(weatherID);
            result = new JsonResult(mapper.Map<List<GetAllPlantsResponse>>(plant));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An exception occurred");
            result = StatusCode(StatusCodes.Status500InternalServerError);
        }

        return result;
    }
}

