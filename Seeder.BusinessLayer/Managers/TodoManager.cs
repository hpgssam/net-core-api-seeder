using System;
using System.Collections.Generic;
using System.Linq;
using Seeder.BusinessLayer.Managers.Interfaces;
using Seeder.Core.Entities.Items;
using Seeder.DataAccessLayer.UoW.Interfaces;

namespace Seeder.BusinessLayer.Managers
{
    public class TodoManager: ITodoManager
    {
        private IUnitOfWork _uow;

        public TodoManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<Todo> GetAll()
        {
            return _uow.TodoRepository.GetAll();
        }

        public Todo Get(int id)
        {
            return _uow.TodoRepository.Get(id);
        }

        public void Add(Todo todo)
        {
            _uow.TodoRepository.Add(todo);
            _uow.SaveChanges();
        }

        public void Update(Todo todo)
        {
            _uow.TodoRepository.Update(todo);
            _uow.SaveChanges();
        }

        public void Delete(int id)
        {
            // TODO: Implement delete method
        }

    }
}
