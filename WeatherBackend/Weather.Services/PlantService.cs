using AutoMapper;
using Newtonsoft.Json;
using Weather.Core.IRepository;
using Weather.Core.IServices;
using Weather.Core.Models;
using Weather.Messages.Responses;

namespace Weather.Services;

public class PlantService : IPlantService
{
    private readonly IMapper mapper;
    private readonly IPlantRepository plantRepository;
    static HttpClient client = new HttpClient();
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

    public async Task<WeatherByLocation> GetWeather(double latitude, double longitude)
    {
        WeatherByLocation weatherResponse = null;
        HttpResponseMessage response = await client.GetAsync(
            $"https://history.openweathermap.org/data/2.5/aggregated/month?month=2&lat={latitude}&lon={longitude}&appid=e3af900cb73aa61dcb9f5811d17cbe5c");
        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            weatherResponse = JsonConvert.DeserializeObject<WeatherByLocation>(json);
        }
        return weatherResponse;
    }
}

