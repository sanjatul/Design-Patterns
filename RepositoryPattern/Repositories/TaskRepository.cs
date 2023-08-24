using Microsoft.EntityFrameworkCore;
using RepositoryPattern.DataAccess;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories.Interfaces;

namespace RepositoryPattern.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly MyDbContext _dbContext;

        public TaskRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskEntity> GetTaskByIdAsync(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }
        public async Task CreateTaskAsync(TaskEntity task)
        {
            await _dbContext.Tasks.AddAsync(task);
        }

        public async Task UpdateTaskAsync(TaskEntity task)
        {
            _dbContext.Tasks.Update(task);
            await Task.CompletedTask;
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _dbContext.Tasks.FindAsync(id);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
            }
        }
    }
}
