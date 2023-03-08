using System;
namespace Weather.Messages.Responses
{
	public class GetPlantsResponse
	{
		public GetPlantsResponse()
		{

		}
        public string Name { get; set; }

        public string Description { get; set; }

		public int WeatherType { get; set; }

    }
}

