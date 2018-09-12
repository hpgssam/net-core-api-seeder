using System;
using System.Linq;

namespace Seeder.BusinessLayer.Managers.Interfaces
{
    public interface IManager<TEntity> where TEntity: class
    {
        IQueryable<TEntity> GetAll();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}
