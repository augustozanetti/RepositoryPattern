using RepositoryPattern.Infra.Contexts;
using System;

namespace RepositoryPattern.Infra.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDataContext _context;

        public UnitOfWork(AppDataContext context)
        {
            _context = context;
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
