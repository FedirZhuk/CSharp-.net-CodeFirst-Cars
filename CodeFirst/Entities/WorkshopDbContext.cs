using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Entities;

public class WorkshopDbContext : DbContext
{
    public DbSet<Car> Cars { get; set; }
    public DbSet<Car_Person> CarPersons { get; set; }
    public DbSet<Person> Persons { get; set; }

    protected WorkshopDbContext()
    {
    }

    public WorkshopDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}