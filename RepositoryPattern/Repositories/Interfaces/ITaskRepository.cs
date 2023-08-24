using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<IEnumerable<TaskEntity>> GetAllTasksAsync();
        Task<TaskEntity> GetTaskByIdAsync(int id);
        Task CreateTaskAsync(TaskEntity task);
        Task UpdateTaskAsync(TaskEntity task);
        Task DeleteTaskAsync(int id);

    }
}
