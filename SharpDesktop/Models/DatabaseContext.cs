using Microsoft.EntityFrameworkCore;
using SharpDesktop.Models.Entity;

namespace SharpDesktop.Models;

/// <summary>
/// 数据库 context
/// </summary>
public class DatabaseContext : DbContext
{

    // ReSharper disable once ConvertToPrimaryConstructor
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Desktop> Desktops { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Desktop>(entity =>
        {
            entity.ToTable("Desktops");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.IconPath)
                .HasMaxLength(100);
            entity.HasKey(e => e.Id);
        });
    }
}