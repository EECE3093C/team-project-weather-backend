using Weather.Core.IRepository;
using Weather.Core.IServices;
using Weather.Core.Models;

namespace Weather.Services;

public class PlantService : IPlantService
{
    private readonly IPlantRepository plantRepository;
    public PlantService(IPlantRepository plantRepository)
    {
        this.plantRepository = plantRepository;
    }

    public async Task<IList<Plant>> GetAllPlantsAsync()
    {
        return await this.plantRepository.GetAllAsync();
    }

    public async Task<IList<Plant>> GetPlantsByWeather(int weatherType)
    {
        return await this.plantRepository.GetAllByConditionAsync(e => e.WeatherTypeFk == weatherType);
    }
}

