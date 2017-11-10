using RepositoryPattern.domain.Entities;
using RepositoryPattern.domain.Repositories;
using RepositoryPattern.Infra.Contexts;
using RepositoryPattern.Infra.UoW;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RepositoryPattern.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private AppDataContext _db;

        public CustomerRepository(AppDataContext db)
        {
            _db = db;
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            _db.Customers.Remove(customer);
        }

        public Customer GetById(int id)
        {
            return _db.Customers.Find(id);
        }

        public IList<Customer> GetByRange(int skip = 0, int take = 25)
        {
            return _db.Customers.OrderBy(x => x.Name).Skip(skip).Take(take).ToList();
        }

        public void Save(Customer customer)
        {
            _db.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _db.Entry<Customer>(customer).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
