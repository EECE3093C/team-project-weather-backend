using System;
using Weather.Infrastructure.Repository;
using Weather.Core.IRepository;
using Weather.Core.Models;

namespace Weather.Infrastructure.Repositories
{
	public class AspNetUserRepository : Repository<AspNetUser>, IAspNetUserRepository
	{
        public AspNetUserRepository(IServiceProvider serviceProvider) : base(serviceProvider)
		{
		}
	}
}

