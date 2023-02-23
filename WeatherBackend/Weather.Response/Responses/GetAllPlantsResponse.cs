using System;
namespace Weather.Messages.Responses
{
	public class GetAllPlantsResponse
	{
		public GetAllPlantsResponse()
		{

		}
        public string PlantName { get; set; }

        public string PlantDescription { get; set; }

		public int WeatherType { get; set; }

    }
}

