using AutoMapper;
using Weather.Core.IRepository;
using Weather.Core.IServices;
using Weather.Core.Models;
using Weather.Messages.Responses;

namespace Weather.Services;

public class PlantService : IPlantService
{
    private readonly IMapper mapper;
    private readonly IPlantRepository plantRepository;
    public PlantService(IPlantRepository plantRepository,
        IMapper mapper)
    {
        this.mapper = mapper;
        this.plantRepository = plantRepository;
    }

    public async Task<IList<GetPlantsResponse>> GetAllPlantsAsync()
    {
        return mapper.Map<List<GetPlantsResponse>>(await this.plantRepository.GetAllAsync());
    }

    public async Task<IList<GetPlantsResponse>> GetPlantsByWeather(int weatherType)
    {
        return mapper.Map<List<GetPlantsResponse>>(await this.plantRepository.GetAllByConditionAsync(e => e.WeatherTypeFk == weatherType));
    }
}

