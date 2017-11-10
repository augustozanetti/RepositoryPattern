using RepositoryPattern.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern.domain.Repositories
{
    public interface ICustomerRepository : IDisposable
    {
        IList<Customer> GetByRange(int skip = 0, int take = 25);
        Customer GetById(int id);
        void Save(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
