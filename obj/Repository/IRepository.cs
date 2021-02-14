
namespace UnityOfWork.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T,bool>> predicate = null);
        
        T GetT(Expression<Func<T,bool>> predicate);

        void Add(T entity);

        void Update(T Entity);

        void Delete(T Entity);

        int Count();        
    }
}