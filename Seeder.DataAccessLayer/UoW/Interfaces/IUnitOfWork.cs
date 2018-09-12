using Seeder.DataAccessLayer.Repositories.Interfaces;

namespace Seeder.DataAccessLayer.UoW.Interfaces
{
    public interface IUnitOfWork
    {
        ITodoRepository TodoRepository { get; }

        void SaveChanges();
    }
}
