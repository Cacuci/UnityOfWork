using System.Data.Entity;
using UnityOfWork.Models;

namespace UnityOfWork.DBContext
{
    public class AplicationContext : DbContext 
    {   
        public virtual DbSet<Client> Clients { get; set; }            
        public virtual DbSet<Product> Products { get; set; }
    }
}
