using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UnityOfWork.DBContext;

namespace UnityOfWork.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AplicationContext _appContext;
        private readonly DbSet<T> _dbSet;

        public Repository(AplicationContext appContext)
        {
            _appContext = appContext;
            _dbSet = _appContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity); 
        }

        public async Task<int> Count()
        {
            return await _dbSet.CountAsync();
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            if (predicate is not null)
            {
                return _dbSet.Where(predicate);
            }

            return _dbSet.AsEnumerable();
        }

        public void Update(T entity)
        {
            _dbSet.Attach(entity);

            ((IObjectContextAdapter)_dbSet).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
    }
}
