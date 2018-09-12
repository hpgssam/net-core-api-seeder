using Seeder.Core.Entities.Items;
using Seeder.DataAccessLayer.Context;
using Seeder.DataAccessLayer.Repositories.Interfaces;

namespace Seeder.DataAccessLayer.Repositories
{
    public class TodoRepository: Repository<Todo>, ITodoRepository
    {
        public TodoRepository(AppDbContext context): base(context)
        {
        }
    }
}
