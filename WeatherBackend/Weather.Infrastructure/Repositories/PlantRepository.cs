using System;
using Weather.Infrastructure.Repository;
using Weather.Core.IRepository;
using Weather.Core.Models;

namespace Weather.Infrastructure.Repositories
{
	public class PlantRepository : Repository<Plant>, IPlantRepository
	{
        public PlantRepository(IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}
	}
}

