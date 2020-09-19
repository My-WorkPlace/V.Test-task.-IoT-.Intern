using Microsoft.EntityFrameworkCore;
using WebServer.Entities;

namespace WebServer.Helpers
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options)
      : base(options)
    {
      Database.EnsureCreated();
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Category> Categories { get; set; }
  }
}
