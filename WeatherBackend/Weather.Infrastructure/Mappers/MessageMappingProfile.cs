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
			CreateMap<Plant, GetPlantsResponse>()
				.ForMember(destination => destination.Name, options => options.MapFrom(source => source.Name))
				 .ForMember(destination => destination.Description, options => options.MapFrom(source => source.Description))
				 .ForMember(destination => destination.WeatherType, options => options.MapFrom(source => source.WeatherTypeFk));

        }
	}
}

