using System;
using Seeder.DataAccessLayer.Context;
using Seeder.DataAccessLayer.Repositories;
using Seeder.DataAccessLayer.Repositories.Interfaces;
using Seeder.DataAccessLayer.UoW.Interfaces;

namespace Seeder.DataAccessLayer.UoW
{
    public class UnitOfWork: IUnitOfWork
    {
        private AppDbContext _context;
        private ITodoRepository _todoRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context), "Context was not supplied");
        }

        public ITodoRepository TodoRepository
        {
            get 
            {
                if (_todoRepository == null)
                {
                    _todoRepository = new TodoRepository(_context);
                }
                return _todoRepository;
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
