using todo_api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace todo_api.Data.Context;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions options)
    : base(options)
    {        
    }

    public DbSet<ToDo> ToDos => Set<ToDo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ToDo>().HasData(
            new ToDo {Id = 1, Name = "Walk dog", IsComplete = true},
            new ToDo {Id = 2, Name = "Go grocery shopping", IsComplete = false},
            new ToDo {Id = 3, Name = "Eat lunch", IsComplete = false}
        );
        base.OnModelCreating(modelBuilder);
    }
}