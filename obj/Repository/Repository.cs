
namespace UnityOfWork.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbSet<T> dbSet;

        public Repository()
        {
            
        }
    }
}