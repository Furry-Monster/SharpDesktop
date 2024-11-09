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
    public DbSet<Launcher> Launchers { get; set; }

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
            entity.HasMany(e => e.Launchers)
                .WithMany(e => e.Desktops);
            entity.HasKey(e => e.Id);
        });

        modelBuilder.Entity<Launcher>(entity =>
        {
            entity.ToTable("Launchers");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Path)
                .HasMaxLength(100);
            entity.Property(e => e.BackgroundPath)
                .HasMaxLength(100);
            entity.HasMany(e => e.Desktops)
                .WithMany(e => e.Launchers);
            entity.HasKey(e => e.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}