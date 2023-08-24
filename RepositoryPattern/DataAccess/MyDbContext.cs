using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;

namespace RepositoryPattern.DataAccess
{
    public class MyDbContext: DbContext
    {
        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
             optionsBuilder.UseInMemoryDatabase(databaseName: "TaskDatabase");
        }
    }
}
