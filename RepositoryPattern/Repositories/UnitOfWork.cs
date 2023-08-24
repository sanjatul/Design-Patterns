using RepositoryPattern.DataAccess;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly MyDbContext _dbContext;

        public ITaskRepository TaskRepository { get; }

        public UnitOfWork(MyDbContext dbContext, ITaskRepository taskRepository)
        {
            _dbContext = dbContext;
            TaskRepository = taskRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
