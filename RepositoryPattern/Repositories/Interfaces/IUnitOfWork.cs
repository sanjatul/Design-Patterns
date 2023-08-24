namespace RepositoryPattern.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskRepository TaskRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
