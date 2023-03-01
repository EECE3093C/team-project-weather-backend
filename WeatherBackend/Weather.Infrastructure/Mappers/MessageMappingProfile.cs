using System;
using AutoMapper;
using Weather.Core.Models;
using Weather.Messages.Responses;

namespace Weather.Infrastructure.Mappers
{
	public class MessageMappingProfile : Profile
	{
		public MessageMappingProfile()
		{
			CreateMap<Plant, GetAllPlantsResponse>()
				.ForMember(destination => destination.PlantName, options => options.MapFrom(source => source.PlantName))
				 .ForMember(destination => destination.PlantDescription, options => options.MapFrom(source => source.PlantDescription))
				 .ForMember(destination => destination.WeatherType, options => options.MapFrom(source => source.WeatherTypeFk));

        }
	}
}

