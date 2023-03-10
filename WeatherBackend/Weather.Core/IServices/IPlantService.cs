using System;
using Weather.Core.Models;
using Weather.Messages.Responses;

namespace Weather.Core.IServices
{
	public interface IPlantService
	{
		Task<IList<GetPlantsResponse>> GetAllPlantsAsync();

		Task<IList<GetPlantsResponse>> GetPlantsByWeather(int weatherType);
        Task<WeatherByLocation> GetWeather(double latitude, double longitude);

    }
}

