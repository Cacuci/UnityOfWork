using System;
using System.Threading.Tasks;
using UnityOfWork.DBContext;
using UnityOfWork.Models;
using UnityOfWork.Repository;

namespace UnityOfWork.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly AplicationContext _aplicationContext;
        
        private IRepository<Client> _clientRepository;
        
        private IRepository<Product> _productRepository;

        public IRepository<Client> ClientRepository
        {
            get
            {
                if (_clientRepository is null)
                {
                    _clientRepository = new Repository<Client>(_aplicationContext); 
                }

                return _clientRepository;
            }
        }

        public IRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository is null)
                {
                    _productRepository = new Repository<Product>(_aplicationContext);
                }

                return _productRepository;
            }
        }

        public UnityOfWork()
        {
            _aplicationContext = new AplicationContext();
        }

        public void Commit()
        {
            _aplicationContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _aplicationContext.SaveChangesAsync();
        }        

        public void Dispose()
        {
            if (_aplicationContext is not null)
            {
                _aplicationContext.Dispose();

                GC.SuppressFinalize(this);
            }            
        }
    }
}
