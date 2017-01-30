using Microsoft.EntityFrameworkCore;
using webApiTutorial.Models;

namespace webApiTutorial.DatabaseContexts 
{
  public class DwContext : DbContext
  {
    public DwContext(DbContextOptions<DwContext> options) : base(options) { }
    public DwContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }

    public DbSet<Book> Books { get; set; }
  }
}