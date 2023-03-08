namespace Weather.Core.IRepository
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(object id);

        Task<T> GetAsync(object[] ids);

        Task<T> GeyByCondition(Expression<Func<T, bool>> expression);

        Task<IList<T>> GetAllByConditionAsync(Expression<Func<T, bool>> expression);

        Task<IList<T>> GetAllAsync();

        Task<T> AddAsync(T obj);

        Task<T> UpdateAsync(T obj);

        Task UpdateMultipleAsync(Expression<Func<T, bool>> predicate, Expression<Func<T, T>> updateAction);

        Task UpdateMultipleAsync(IList<T> objs);

        Task DeleteAsync(object id);

        Task DeleteAsync(T obj);

        Task AddMultipleAsync(IList<T> objs);

        Task DeleteMultipleAsync(Expression<Func<T, bool>> predicate);
    }
}
