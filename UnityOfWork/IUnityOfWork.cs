using UnityOfWork.Models;
using UnityOfWork.Repository;

namespace UnityOfWork.UnityOfWork
{
    public interface IUnityOfWork
    {
        IRepository<Client> ClientRepository { get; }
        IRepository<Product> ProductRepository { get; }
    }
}
