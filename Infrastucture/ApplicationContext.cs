using Domain;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ConsoleApp1;
internal class ApplicationContext : DbContext, IUnitOfWork
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Post> Posts => Set<Post>();
    public ApplicationContext()
    {
        //Database.EnsureCreated();
    }

    protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
    {
        optionsBuilder.UseSqlite( "Data Source=helloapp.db" );
        optionsBuilder.LogTo( Console.WriteLine, new[] { RelationalEventId.CommandExecuted } );
    }

    public void Commit()
    {
        SaveChanges();
    }
}
