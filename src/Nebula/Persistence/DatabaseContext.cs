using Microsoft.EntityFrameworkCore;
using Nebula.Domain.Entities;

namespace Nebula.Persistence;

public sealed class DatabaseCotnext : DbContext
{
    public DatabaseCotnext(DbContextOptions<DatabaseCotnext> options): base(options) 
    {
        Database.EnsureCreated();
    }

    public DbSet<Password> Passwords { get; set; }
}