using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using webApiTutorial.Models;
using System.Reflection;

namespace webApiTutorial.DatabaseContexts 
{
  public class DwContext : DbContext
  {
    public DwContext(DbContextOptions<DwContext> options) : base(options) { }
    public DwContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // Create our audit fields as shadow properties
      foreach (var entityType in modelBuilder.Model.GetEntityTypes()
            .Where(e => typeof(IAuditable).IsAssignableFrom(e.ClrType)))
      {
        modelBuilder.Entity(entityType.ClrType)
            .Property<DateTime>("Created");
        
        modelBuilder.Entity(entityType.ClrType)
            .Property<DateTime?>("Modified");
            
        modelBuilder.Entity(entityType.ClrType)
            .Property<string>("CreatedBy");
        
        modelBuilder.Entity(entityType.ClrType)
            .Property<string>("ModifiedBy");
      }

      modelBuilder.Entity<BookCharacter>().HasKey(x => new { x.BookId, x.CharacterId });

      base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
      ApplyAuditInformation();
      return base.SaveChanges();
    }

    private void ApplyAuditInformation()
    {
      var modifiedEntities = ChangeTracker.Entries<IAuditable>()
          .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);
      foreach (var entity in modifiedEntities)
      {
        entity.Property("Modified").CurrentValue = DateTime.UtcNow;
        entity.Property("ModifiedBy").CurrentValue = String.Empty;
        if (entity.State == EntityState.Added)
        {
          entity.Property("Created").CurrentValue = DateTime.UtcNow;
          entity.Property("CreatedBy").CurrentValue = "Migration";
        }
      }
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Character> Characters { get; set; }

    public DbSet<BookCharacter> BookCharacters { get; set; }
  }
}