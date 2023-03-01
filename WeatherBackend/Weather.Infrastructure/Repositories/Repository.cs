using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Weather.Core.IRepository;
using Weather.Core.Models;
using Z.EntityFramework.Plus;

namespace Weather.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly PlantDbContext _context;

        public Repository(IServiceProvider serviceProvider)
        {
            _context = (PlantDbContext)serviceProvider.GetService(typeof(PlantDbContext));
        }

        public async Task<T> GetAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetAsync(object[] ids)
        {
            return await _context.Set<T>().FindAsync(ids);
        }

        public async Task<IList<T>> GetAllByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>()
                                 .AsNoTracking()
                                 .Where(expression)
                                 .ToListAsync();
        }

        public async Task<IList<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> AddAsync(T obj)
        {
            var entity = await _context.AddAsync(obj);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task<T> UpdateAsync(T obj)
        {
            var result = _context.Update(obj);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task UpdateMultipleAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateAction)
        {
            await _context.Set<T>().Where(predicate).UpdateAsync(updateAction);
        }

        public async Task UpdateMultipleAsync(IList<T> objs)
        {
            _context.Set<T>().UpdateRange(objs);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(object id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(T obj)
        {
            if (obj != null)
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddMultipleAsync(IList<T> objs)
        {
            await _context.Set<T>().AddRangeAsync(objs);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMultipleAsync(Expression<Func<T, bool>> predicate)
        {
            await _context.Set<T>().Where(predicate).DeleteAsync();
        }
    }
}