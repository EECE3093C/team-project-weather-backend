using System;
using Weather.Core.Models;

namespace Weather.Core.IServices
{
	public interface IPlantService
	{
		Task<IList<Plant>> GetAllPlantsAsync();

		Task<IList<Plant>> GetPlantsByWeather(int weatherType);

    }
}

